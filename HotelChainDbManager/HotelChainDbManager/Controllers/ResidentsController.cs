using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelChainDbManager.Data;

namespace HotelChainDbManager.Controllers;

public class ResidentsController : Controller
{
    private readonly HotelChainDbContext _context;

    public ResidentsController(HotelChainDbContext context)
    {
        _context = context;
    }

    // GET: Residents
    public async Task<IActionResult> Index()
    {
        return View(await _context.Residents.ToListAsync());
    }

    // GET: Residents/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Residents/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdCardNumber,Name,Surname,Patronimic,DateOfBirth,Gender")] Resident resident)
    {
        if (ModelState.IsValid)
        {
            _context.Add(resident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(resident);
    }

    // GET: Residents/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resident = await _context.Residents.FindAsync(id);
        if (resident == null)
        {
            return NotFound();
        }
        return View(resident);
    }

    // POST: Residents/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdCardNumber,Name,Surname,Patronimic,DateOfBirth,Gender")] Resident resident)
    {
        if (id != resident.IdCardNumber)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(resident);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(resident.IdCardNumber))
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
        return View(resident);
    }

    // GET: Residents/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resident = await _context.Residents
            .FirstOrDefaultAsync(m => m.IdCardNumber == id);
        if (resident == null)
        {
            return NotFound();
        }

        return View(resident);
    }

    // POST: Residents/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var resident = await _context.Residents.FindAsync(id);
        if (resident != null)
        {
            _context.Residents.Remove(resident);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ResidentExists(int id)
    {
        return _context.Residents.Any(e => e.IdCardNumber == id);
    }
}
