using AutoMapper;
using DAL.Entities;

namespace LOGIC.Models
{
    public class LogicApplicationProfile: Profile
    {
        public LogicApplicationProfile()
        {
            CreateMap<Jobs, JobEntity>();
        }
    }
}
