using HR_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.ServicesInterfaces
{
    public interface IJobService
    {
        Task<bool> CreateJob(string JobTitle);
        Task<IEnumerable<Job>> GetJobs();
    }
}
