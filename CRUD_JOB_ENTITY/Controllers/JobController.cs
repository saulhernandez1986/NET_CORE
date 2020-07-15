using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_JOB_ENTITY.DAL;
using CRUD_JOB_ENTITY.Models;

namespace CRUD_JOB_ENTITY.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Job
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jobs.ToListAsync());
        }

        // GET: Job/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await _context.Jobs
                .FirstOrDefaultAsync(m => m.Job == id);
            if (jobEntity == null)
            {
                return NotFound();
            }

            return View(jobEntity);
        }

        // GET: Job/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Job,JobTitle,Description,CreatedAt,ExpiresdAt")] JobEntity jobEntity)
        {
            if (ModelState.IsValid)
            {
                jobEntity.Job = Guid.NewGuid();
                _context.Add(jobEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntity);
        }

        // GET: Job/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await _context.Jobs.FindAsync(id);
            if (jobEntity == null)
            {
                return NotFound();
            }
            return View(jobEntity);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Job,JobTitle,Description,CreatedAt,ExpiresdAt")] JobEntity jobEntity)
        {
            if (id != jobEntity.Job)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobEntityExists(jobEntity.Job))
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
            return View(jobEntity);
        }

        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await _context.Jobs
                .FirstOrDefaultAsync(m => m.Job == id);
            if (jobEntity == null)
            {
                return NotFound();
            }

            return View(jobEntity);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jobEntity = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(jobEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobEntityExists(Guid id)
        {
            return _context.Jobs.Any(e => e.Job == id);
        }
    }
}
