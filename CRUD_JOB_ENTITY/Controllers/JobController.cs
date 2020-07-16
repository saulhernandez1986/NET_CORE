using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUD_JOB_ENTITY.Models;
using LOGIC.JobLogic;
using AutoMapper;
using System.Collections.Generic;
using LOGIC.Models;

namespace CRUD_JOB_ENTITY.Controllers
{
    public class JobController : Controller
    {


        private readonly IMapper _mapper;
        public JobLogic _jobLogic = new JobLogic();

        public JobController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: Job
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobLogic.GetAllJobs();
            var model = _mapper.Map<IEnumerable<JobEntityDTO>>(jobs);

            return View(model);
        }


        // GET: Job/Create
        public IActionResult AddOrEdit(Guid id = new Guid())
        {
            var guidIsEmpty = id == Guid.Empty;

            if (guidIsEmpty)
            {
                return View(new JobEntityDTO());
            }
            else
            {
                var job = _jobLogic.GetJobById(id);
                var model = _mapper.Map<JobEntityDTO>(job);
                return View(model);
            }
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Job,JobTitle,Description,CreatedAt,ExpiresdAt")] JobEntityDTO jobEntity)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<JobEntity>(jobEntity);
                await _jobLogic.AddOrEdit(model);
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntity);
        }


        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var model = await _jobLogic.Delete(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
