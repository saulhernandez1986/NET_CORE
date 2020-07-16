using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class JobFunctions : IJobEntity
    {
        private readonly ApplicationDbContext _context;
        //public async Task<JobEntity> GetJobList()
        //{
        //    private readonly ApplicationDbContext _context;
        //    //using (var _context = ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
        //    //{

        //    //}
        //    return await _context.Jobs.ToListAsync();

        //}

        public async Task<List<Jobs>> GetAllJobs()
        {
            List<Jobs> jobs = new List<Jobs>();
            using (var _context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                jobs = await _context.Jobs.ToListAsync();
            }
            
            return jobs;
        }

        public async Task<Jobs> AddOrEdit(Jobs j)
        {
            var guidIsEmpty = j.Job == Guid.Empty;
            if (guidIsEmpty)
            {
                j.Job = Guid.NewGuid();
                _context.Add(j);
            }
            else
            {
                _context.Update(j);
            }
            await _context.SaveChangesAsync();
            return j;
        }
    }
}
