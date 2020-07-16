
using DAL.Interfaces;
using DAL.Functions;
using System;
using System.Collections.Generic;
using DAL.Entities;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using LOGIC.Models;

namespace LOGIC.JobLogic
{
    public class JobLogic
    {

        private IJobEntity _Job = new JobFunctions();

        private readonly IMapper _mapper;
        public JobLogic(IMapper mapper)
        {
            _mapper = mapper;
        }


        //Add or edit jobs
        public async Task<Boolean> AddOrEdit(Jobs j)
        {
            try
            {
                var result = await _Job.AddOrEdit(j);
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

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Jobs, JobEntity>();
            });
            IMapper iMapper = config.CreateMapper();
            //var source = new DAL.Entities.JobEntity();
            var destination = iMapper.Map<List<Jobs>, List<JobEntity>>(jobs);
            //var config = new MapperConfiguration(mc => mc.CreateMap<DAL.Entities.JobEntity, LOGIC.Models.JobEntity>());
            //var mapper = new Mapper(config);
            //var result = mapper.Map<List<DAL.Entities.JobEntity>, List<LOGIC.Models.JobEntity>>(jobs);
            //var job = iMapper.Map<List<LOGIC.Models.JobEntity>>(jobs);

            //List<LOGIC.Models.JobEntity> jobs = await _Job.GetAllJobs();
            return destination;
        }

    }
}
