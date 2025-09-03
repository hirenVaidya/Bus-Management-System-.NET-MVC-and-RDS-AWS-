using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bus_Management_System.Data;
using Bus_Management_System.Models;

namespace shuttle.Views
{
    [Authorize]
    public class AddBusEntitiesController : Controller
    {
        private readonly AddBusDbContext _context;

        public AddBusEntitiesController(AddBusDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.AddBus != null ?
                        View(await _context.AddBus.ToListAsync()) :
                        Problem("Entity set 'AddBusDbContext.AddBus'  is null.");
        }
        // GET: AddBusEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AddBus == null)
            {
                return NotFound();
            }

            var addBusEntity = await _context.AddBus
                .FirstOrDefaultAsync(m => m.BusNo == id);
            if (addBusEntity == null)
            {
                return NotFound();
            }

            return View(addBusEntity);
        }

        // GET: AddBusEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddBusEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusNo,BusName,Bustype,SeatColumns,SeatRow,Origin,Destination")] AddBusEntity addBusEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addBusEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addBusEntity);
        }

        // GET: AddBusEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddBus == null)
            {
                return NotFound();
            }

            var addBusEntity = await _context.AddBus.FindAsync(id);
            if (addBusEntity == null)
            {
                return NotFound();
            }
            return View(addBusEntity);
        }

        // POST: AddBusEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusNo,BusName,Bustype,SeatColumns,SeatRow,Origin,Destination")] AddBusEntity addBusEntity)
        {
            if (id != addBusEntity.BusNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addBusEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddBusEntityExists(addBusEntity.BusNo))
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
            return View(addBusEntity);
        }

        // GET: AddBusEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddBus == null)
            {
                return NotFound();
            }

            var addBusEntity = await _context.AddBus
                .FirstOrDefaultAsync(m => m.BusNo == id);
            if (addBusEntity == null)
            {
                return NotFound();
            }

            return View(addBusEntity);
        }

        // POST: AddBusEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddBus == null)
            {
                return Problem("Entity set 'AddBusDbContext.AddBus'  is null.");
            }
            var addBusEntity = await _context.AddBus.FindAsync(id);
            if (addBusEntity != null)
            {
                _context.AddBus.Remove(addBusEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddBusEntityExists(int id)
        {
            return (_context.AddBus?.Any(e => e.BusNo == id)).GetValueOrDefault();
        }
    }
}
