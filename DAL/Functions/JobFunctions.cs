using AutoMapper;
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

        public async Task<List<Jobs>> GetAllJobs()
        {
            List<Jobs> jobs = new List<Jobs>();
            using (var _context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                jobs = await _context.Jobs.ToListAsync();
            }
            
            return jobs;
        }

        public Jobs GetJobById(Guid id)
        {
            Jobs job = new Jobs();
            using (var _context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                job = _context.Jobs.Find(id);
            }
            return job;
        }

        public async Task<Jobs> AddOrEdit(Jobs j)
        {
            var guidIsEmpty = j.Job == Guid.Empty;
            using (var _context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
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
            }
            
            return j;
        }

        public async Task<Jobs> Delete(Guid? id)
        {
            Jobs job = new Jobs();
            using (var _context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                job = _context.Jobs.Find(id);
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
            
            return job;
        }
    }
}
