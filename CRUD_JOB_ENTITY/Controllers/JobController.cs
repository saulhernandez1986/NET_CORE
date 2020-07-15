using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_JOB_ENTITY.DAL;
using CRUD_JOB_ENTITY.Models;

using LOGICAL.Models;

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


        // GET: Job/Create
        public IActionResult AddOrEdit(Guid id = new Guid())
        {
            var guidIsEmpty = id == Guid.Empty;

            if (guidIsEmpty)
                return View(new Models.JobEntity());
            else
                return View(_context.Jobs.Find(id));
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Job,JobTitle,Description,CreatedAt,ExpiresdAt")] Models.JobEntity jobEntity)
        {
            if (ModelState.IsValid)
            {
                var guidIsEmpty = jobEntity.Job == Guid.Empty;

                if (guidIsEmpty)
                {
                    jobEntity.Job = Guid.NewGuid();
                    _context.Add(jobEntity);
                }
                else
                {
                    _context.Update(jobEntity);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntity);
        }


        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var jobEntity = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(jobEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
