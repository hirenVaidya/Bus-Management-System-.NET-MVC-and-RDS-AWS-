using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shuttle.Data;
using Bus_Management_System.Models;
using Bus_Management_System.Data.shuttle.Data;


namespace shuttle.Views
{
    [Authorize]
    public class LeadDetailsEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadDetailsEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeadDetailsEntities
        public async Task<IActionResult> Index()
        {
            return _context.LeadDetails != null ?
                        View(await _context.LeadDetails.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.LeadDetails'  is null.");
        }

        // GET: LeadDetailsEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeadDetails == null)
            {
                return NotFound();
            }

            var leadDetailsEntity = await _context.LeadDetails
                .FirstOrDefaultAsync(m => m.LeadId == id);
            if (leadDetailsEntity == null)
            {
                return NotFound();
            }

            return View(leadDetailsEntity);
        }

        // GET: LeadDetailsEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeadDetailsEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeadId,Firstname,Lastname,Mobile,Email")] LeadDetailsEntity leadDetailsEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leadDetailsEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadDetailsEntity);
        }

        // GET: LeadDetailsEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeadDetails == null)
            {
                return NotFound();
            }

            var leadDetailsEntity = await _context.LeadDetails.FindAsync(id);
            if (leadDetailsEntity == null)
            {
                return NotFound();
            }
            return View(leadDetailsEntity);
        }

        // POST: LeadDetailsEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeadId,Firstname,Lastname,Mobile,Email")] LeadDetailsEntity leadDetailsEntity)
        {
            if (id != leadDetailsEntity.LeadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadDetailsEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadDetailsEntityExists(leadDetailsEntity.LeadId))
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
            return View(leadDetailsEntity);
        }

        // GET: LeadDetailsEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeadDetails == null)
            {
                return NotFound();
            }

            var leadDetailsEntity = await _context.LeadDetails
                .FirstOrDefaultAsync(m => m.LeadId == id);
            if (leadDetailsEntity == null)
            {
                return NotFound();
            }

            return View(leadDetailsEntity);
        }

        // POST: LeadDetailsEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeadDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeadDetails'  is null.");
            }
            var leadDetailsEntity = await _context.LeadDetails.FindAsync(id);
            if (leadDetailsEntity != null)
            {
                _context.LeadDetails.Remove(leadDetailsEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadDetailsEntityExists(int id)
        {
            return (_context.LeadDetails?.Any(e => e.LeadId == id)).GetValueOrDefault();
        }
    }
}




