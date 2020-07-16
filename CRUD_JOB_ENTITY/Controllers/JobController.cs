using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUD_JOB_ENTITY.Models;

using LOGIC.Models;
using LOGIC.JobLogic;
using System.Collections.Generic;
using AutoMapper;

namespace CRUD_JOB_ENTITY.Controllers
{
    public class JobController : Controller
    {
        //private readonly ApplicationDbContext _context;

        
        public JobLogic _jobLogic = new JobLogic();

        public JobController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //public JobController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Job
        public async Task<IActionResult> Index()
        {
            //IEnumerable<CRUD_JOB_ENTITY.Models.JobEntity> jobs= await _jobLogic.GetAllJobs();
            //var jobs = await _jobLogic.GetAllJobs();
            //var config = new MapperConfiguration(mc => mc.CreateMap<JobEntity, JobEntityDTO>());
            //var mapper = new Mapper(config);
            //var result = mapper.Map<List<JobEntity>, List<JobEntityDTO>>(jobs);
            //IEnumerable<CRUD_JOB_ENTITY.Models.JobEntity> j = (IEnumerable<CRUD_JOB_ENTITY.Models.JobEntity>)g;

            return View(await _jobLogic.GetAllJobs());
            //return View(await _context.Jobs.ToListAsync());
        }


        // GET: Job/Create
        //public IActionResult AddOrEdit(Guid id = new Guid())
        //{
        //    var guidIsEmpty = id == Guid.Empty;

        //    if (guidIsEmpty)
        //        return View(new Models.JobEntity());
        //    else
        //        return View(_context.Jobs.Find(id));
        //}

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Job,JobTitle,Description,CreatedAt,ExpiresdAt")] Models.JobEntityDTO jobEntity)
        {
            if (ModelState.IsValid)
            {
                //var guidIsEmpty = jobEntity.Job == Guid.Empty;

                //if (guidIsEmpty)
                //{
                //    jobEntity.Job = Guid.NewGuid();
                //    _context.Add(jobEntity);
                //}
                //else
                //{
                //    _context.Update(jobEntity);
                //}
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntity);
        }


        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            //var jobEntity = await _context.Jobs.FindAsync(id);
            //_context.Jobs.Remove(jobEntity);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
