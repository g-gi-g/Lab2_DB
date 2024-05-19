using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelChainDbManager.Data;

namespace HotelChainDbManager.Controllers
{
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

        // GET: Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents
                .Include(r => r.ResidentNavigation)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Resident == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            ViewData["Resident"] = new SelectList(_context.Residents, "IdCardNumber", "IdCardNumber");
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
            if (ModelState.IsValid)
            {
                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Resident"] = new SelectList(_context.Residents, "IdCardNumber", "IdCardNumber", rent.Resident);
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number", rent.RoomNumber);
            return View(rent);
        }

        // GET: Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }
            ViewData["Resident"] = new SelectList(_context.Residents, "IdCardNumber", "IdCardNumber", rent.Resident);
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number", rent.RoomNumber);
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Resident,RoomNumber,HotelNumber,CostPerDay,RentStart,RentEnd")] Rent rent)
        {
            if (id != rent.Resident)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.Resident))
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
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "Number", "Number", rent.RoomNumber);
            return View(rent);
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents
                .Include(r => r.ResidentNavigation)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Resident == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rent = await _context.Rents.FindAsync(id);
            if (rent != null)
            {
                _context.Rents.Remove(rent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
            return _context.Rents.Any(e => e.Resident == id);
        }
    }
}
