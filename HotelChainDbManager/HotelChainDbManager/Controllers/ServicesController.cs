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

public class ServicesController : Controller
{
    private readonly HotelChainDbContext _context;

    public ServicesController(HotelChainDbContext context)
    {
        _context = context;
    }

    // GET: Services
    public async Task<IActionResult> Index()
    {
        var hotelChainDbContext = _context.Services.Include(s => s.Employee).Include(s => s.Room);
        return View(await hotelChainDbContext.ToListAsync());
    }

    // GET: Services/Create
    public IActionResult Create()
    {
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdCardNumber", "IdCardNumber");
        ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number");
        ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number");
        return View();
    }

    // POST: Services/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmployeeId,RoomNumber,HotelNumber")] Service service)
    {
        if (ServiceExists(service))
        {
            ModelState.AddModelError("HotelNumber", "Ви не можете використати цей ключ");
            ModelState.AddModelError("RoomNumber", "Ви не можете використати цей ключ");
            ModelState.AddModelError("EmployeeId", "Ви не можете використати цей ключ");
            ModelState["HotelNumber"].ValidationState = ModelValidationState.Invalid;
            ModelState["RoomNumber"].ValidationState = ModelValidationState.Invalid;
            ModelState["EmployeeId"].ValidationState = ModelValidationState.Invalid;
        }

        if (!RoomExists(service.HotelNumber, service.RoomNumber))
        {
            ModelState.AddModelError("HotelNumber", "Ви не можете використати цей ключ");
            ModelState.AddModelError("RoomNumber", "Ви не можете використати цей ключ");
            ModelState.AddModelError("EmployeeId", "Ви не можете використати цей ключ");
            ModelState["HotelNumber"].ValidationState = ModelValidationState.Invalid;
            ModelState["RoomNumber"].ValidationState = ModelValidationState.Invalid;
            ModelState["EmployeeId"].ValidationState = ModelValidationState.Invalid;
        }

        ModelState["Employee"].ValidationState = ModelValidationState.Valid;
        ModelState["Room"].ValidationState = ModelValidationState.Valid;

        if (ModelState.IsValid)
        {
            _context.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdCardNumber", "IdCardNumber", service.EmployeeId);
        ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", service.HotelNumber);
        ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number", service.RoomNumber);
        return View(service);
    }

    // GET: Services/Edit/5
    public async Task<IActionResult> Edit(Service service)
    {
        if (service == null)
        {
            return NotFound();
        }
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdCardNumber", "IdCardNumber", service.EmployeeId);
        ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", service.HotelNumber);
        ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number", service.RoomNumber);
        return View(service);
    }

    // POST: Services/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,RoomNumber,HotelNumber")] Service service)
    {
        ModelState["Employee"].ValidationState = ModelValidationState.Valid;
        ModelState["Room"].ValidationState = ModelValidationState.Valid;

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(service);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(service))
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
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdCardNumber", "IdCardNumber", service.EmployeeId);
        ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", service.HotelNumber);
        ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number", service.RoomNumber);
        return View(service);
    }

    // GET: Services/Delete/5
    public async Task<IActionResult> Delete(Service service)
    {
        if (service == null)
        {
            return NotFound();
        }

        return View(service);
    }

    // POST: Services/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Service service)
    {
        if (service != null)
        {
            _context.Services.Remove(service);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ServiceExists(Service service)
    {
        return _context.Services.Any(e => e.RoomNumber == service.RoomNumber 
        && e.HotelNumber == service.HotelNumber && e.EmployeeId == service.EmployeeId);
    }

    private bool RoomExists(int hotelNumber, int roomNumber)
    {
        return _context.Rooms.Any(m => m.Number == roomNumber && m.HotelNumber == hotelNumber);
    }
}
