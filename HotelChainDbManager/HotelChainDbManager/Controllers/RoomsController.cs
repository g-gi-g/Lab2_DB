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
    public class RoomsController : Controller
    {
        private readonly HotelChainDbContext _context;

        public RoomsController(HotelChainDbContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var hotelChainDbContext = _context.Rooms.Include(r => r.ClassNavigation).Include(r => r.HotelNumberNavigation);
            return View(await hotelChainDbContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.ClassNavigation)
                .Include(r => r.HotelNumberNavigation)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["Class"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,HotelNumber,Class,Capacity")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Class"] = new SelectList(_context.Classes, "Id", "Id", room.Class);
            ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", room.HotelNumber);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["Class"] = new SelectList(_context.Classes, "Id", "Id", room.Class);
            ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", room.HotelNumber);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Number,HotelNumber,Class,Capacity")] Room room)
        {
            if (id != room.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Number))
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
            ViewData["Class"] = new SelectList(_context.Classes, "Id", "Id", room.Class);
            ViewData["HotelNumber"] = new SelectList(_context.Hotels, "Number", "Number", room.HotelNumber);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.ClassNavigation)
                .Include(r => r.HotelNumberNavigation)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Number == id);
        }
    }
}
