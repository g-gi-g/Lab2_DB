using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelChainDbManager.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace HotelChainDbManager.Controllers;

public class CompanyPositionsController : Controller
{
    private readonly HotelChainDbContext _context;

    public CompanyPositionsController(HotelChainDbContext context)
    {
        _context = context;
    }

    // GET: CompanyPositions
    public async Task<IActionResult> Index()
    {
        return View(await _context.CompanyPositions.ToListAsync());
    }

    // GET: CompanyPositions/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CompanyPositions/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,WorkingRate")] CompanyPosition companyPosition)
    {
        if (CompanyPositionExists(@companyPosition.Id))
        {
            ModelState.AddModelError("Id", "Ви не можете використати цей ключ");
            ModelState["Id"].ValidationState = ModelValidationState.Invalid;
        }

        if (ModelState.IsValid)
        {
            _context.Add(companyPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(companyPosition);
    }

    // GET: CompanyPositions/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var companyPosition = await _context.CompanyPositions.FindAsync(id);
        if (companyPosition == null)
        {
            return NotFound();
        }
        return View(companyPosition);
    }

    // POST: CompanyPositions/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WorkingRate")] CompanyPosition companyPosition)
    {
        if (id != companyPosition.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(companyPosition);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyPositionExists(companyPosition.Id))
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
        return View(companyPosition);
    }

    // GET: CompanyPositions/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var companyPosition = await _context.CompanyPositions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (companyPosition == null)
        {
            return NotFound();
        }

        return View(companyPosition);
    }

    // POST: CompanyPositions/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var companyPosition = await _context.CompanyPositions.FindAsync(id);
        if (companyPosition != null)
        {
            _context.CompanyPositions.Remove(companyPosition);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CompanyPositionExists(int id)
    {
        return _context.CompanyPositions.Any(e => e.Id == id);
    }
}
