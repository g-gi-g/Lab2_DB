using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelChainDbManager.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelChainDbManager.Controllers;

public class RentsController : Controller
{
    private readonly HotelChainDbContext _context;

    public RentsController(HotelChainDbContext context)
    {
        _context = context;
    }

    // GET: Rents
    public async Task<IActionResult> Index()
    {
        var hotelChainDbContext = _context.Rents.Include(r => r.ResidentNavigation).Include(r => r.Room);
        return View(await hotelChainDbContext.ToListAsync());
    }

    // GET: Rents/Create
    public IActionResult Create()
    {
        ViewData["Resident"] = new SelectList(_context.Residents, "IdCardNumber", "IdCardNumber");
        ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number");
        ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number");
        return View();
    }

    // POST: Rents/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Resident,RoomNumber,HotelNumber,CostPerDay,RentStart,RentEnd")] Rent rent)
    {
        if (!RoomExists(rent.HotelNumber, rent.RoomNumber))
        {
            ModelState.AddModelError("HotelNumber", "Ви не можете використати цей ключ");
            ModelState.AddModelError("RoomNumber", "Ви не можете використати цей ключ");
            ModelState["HotelNumber"].ValidationState = ModelValidationState.Invalid;
            ModelState["RoomNumber"].ValidationState = ModelValidationState.Invalid;
        }

        ModelState["Room"].ValidationState = ModelValidationState.Valid;
        ModelState["ResidentNavigation"].ValidationState = ModelValidationState.Valid;

        if (ModelState.IsValid)
        {
            _context.Add(rent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Resident"] = new SelectList(_context.Residents, "IdCardNumber", "IdCardNumber", rent.Resident);
        ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", rent.HotelNumber);
        ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number", rent.RoomNumber);
        return View(rent);
    }

    // GET: Rents/Edit/5
    public async Task<IActionResult> Edit(Rent rent)
    {
        if (rent == null)
        {
            return NotFound();
        }
        return View(rent);
    }

    // POST: Rents/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Resident,RoomNumber,HotelNumber,CostPerDay,RentStart,RentEnd")]  Rent rent)
    {
        ModelState["Room"].ValidationState = ModelValidationState.Valid;
        ModelState["ResidentNavigation"].ValidationState = ModelValidationState.Valid;

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(rent);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(rent))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["Resident"] = new SelectList(_context.Residents, "IdCardNumber", "IdCardNumber", rent.Resident);
        ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", rent.HotelNumber);
        ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number", rent.RoomNumber);
        return View(rent);
    }

    // GET: Rents/Delete/5
    public async Task<IActionResult> Delete(Rent rent)
    {
        if (rent == null)
        {
            return NotFound();
        }

        return View(rent);
    }

    // POST: Rents/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Rent rent)
    {
        if (rent != null)
        {
            _context.Rents.Remove(rent);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RentExists(Rent _rent)
    {
        return _context.Rents.Any(m => m.Resident == _rent.Resident && m.HotelNumber == _rent.HotelNumber && m.RoomNumber == _rent.RoomNumber);
    }

    private bool RoomExists(int hotelNumber, int roomNumber)
    {
        return _context.Rooms.Any(m => m.Number == roomNumber && m.HotelNumber == hotelNumber);
    }
}
