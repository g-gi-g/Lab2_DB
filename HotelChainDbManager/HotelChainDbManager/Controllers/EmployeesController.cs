﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelChainDbManager.Data;

namespace HotelChainDbManager.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HotelChainDbContext _context;

        public EmployeesController(HotelChainDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var hotelChainDbContext = _context.Employees.Include(e => e.CompanyPositionNavigation).Include(e => e.HotelNumberNavigation);
            return View(await hotelChainDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.CompanyPositionNavigation)
                .Include(e => e.HotelNumberNavigation)
                .FirstOrDefaultAsync(m => m.IdCardNumber == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["CompanyPosition"] = new SelectList(_context.CompanyPositions, "Id", "Id");
            ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCardNumber,Name,Surname,Patronimic,DateOfBirth,Gender,CompanyPosition,HotelNumber")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyPosition"] = new SelectList(_context.CompanyPositions, "Id", "Id", employee.CompanyPosition);
            ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", employee.HotelNumber);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CompanyPosition"] = new SelectList(_context.CompanyPositions, "Id", "Id", employee.CompanyPosition);
            ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", employee.HotelNumber);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCardNumber,Name,Surname,Patronimic,DateOfBirth,Gender,CompanyPosition,HotelNumber")] Employee employee)
        {
            if (id != employee.IdCardNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.IdCardNumber))
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
            ViewData["CompanyPosition"] = new SelectList(_context.CompanyPositions, "Id", "Id", employee.CompanyPosition);
            ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", employee.HotelNumber);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.CompanyPositionNavigation)
                .Include(e => e.HotelNumberNavigation)
                .FirstOrDefaultAsync(m => m.IdCardNumber == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.IdCardNumber == id);
        }
    }
}
