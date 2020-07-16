using AutoMapper;
using CRUD_JOB_ENTITY.Models;
using LOGIC.Models;

namespace CRUD_JOB_ENTITY.Utility
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile()
        {
            CreateMap<JobEntity, JobEntityDTO>();
        }
        
    }
}
