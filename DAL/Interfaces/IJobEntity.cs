using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IJobEntity
    {
        Task<Jobs> AddOrEdit(Jobs j);
        Task<List<Jobs>> GetAllJobs();
    }
}
