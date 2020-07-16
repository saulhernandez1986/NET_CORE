
using DAL.Interfaces;
using DAL.Functions;
using System;
using System.Collections.Generic;
using DAL.Entities;
using System.Threading.Tasks;
using AutoMapper;
using LOGIC.Models;

namespace LOGIC.JobLogic
{
    public class JobLogic
    {

        private IJobEntity _Job = new JobFunctions();

        private readonly IMapper _mapper;

        public JobLogic()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<LogicApplicationProfile>();
            });

            var mapper = config.CreateMapper();
            _mapper = mapper;
        }


        //Add or edit jobs
        public async Task<Boolean> AddOrEdit(JobEntity j)
        {
            try
            {
                var model = _mapper.Map<Jobs>(j);
                var result = await _Job.AddOrEdit(model);
                if (result.Job == Guid.Empty)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception error)
            {

                return false;
            }
        }

        public async Task<List<JobEntity>> GetAllJobs()
        {
            var jobs = await _Job.GetAllJobs();
            var model = _mapper.Map<List<JobEntity>>(jobs);
            return model;
        }

        public JobEntity GetJobById(Guid id)
        {
            var job = _Job.GetJobById(id);
            var model = _mapper.Map<JobEntity>(job);
            return model;
        }

        public async Task<JobEntity> Delete(Guid? id)
        {
            var job = await _Job.Delete(id);
            var model = _mapper.Map<JobEntity>(job);
            return model;
        }
    }
}
