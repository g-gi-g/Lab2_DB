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

public class HotelsController : Controller
{
    private readonly HotelChainDbContext _context;

    public HotelsController(HotelChainDbContext context)
    {
        _context = context;
    }

    // GET: Hotels
    public async Task<IActionResult> Index()
    {
        return View(await _context.Hotels.ToListAsync());
    }

    // GET: Hotels/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Hotels/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Number,Adress")] Hotel hotel)
    {
        if (HotelExists(hotel.Number))
        {
            ModelState.AddModelError("Number", "Ви не можете використати цей ключ");
            ModelState["Number"].ValidationState = ModelValidationState.Invalid;
        }

        if (ModelState.IsValid)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(hotel);
    }

    // GET: Hotels/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }
        return View(hotel);
    }

    // POST: Hotels/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Number,Adress")] Hotel hotel)
    {
        if (id != hotel.Number)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(hotel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(hotel.Number))
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
        return View(hotel);
    }

    // GET: Hotels/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hotel = await _context.Hotels
            .FirstOrDefaultAsync(m => m.Number == id);
        if (hotel == null)
        {
            return NotFound();
        }

        return View(hotel);
    }

    // POST: Hotels/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel != null)
        {
            _context.Hotels.Remove(hotel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HotelExists(int id)
    {
        return _context.Hotels.Any(e => e.Number == id);
    }
}
