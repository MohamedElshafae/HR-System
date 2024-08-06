using HR_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.Interfaces
{
    public interface IJobRepository
    {
        Task CreateJob(Job Job);
        Task<bool> isExist(string jobTitle);
        Task<IEnumerable<Job>> GetJobs();
    }
}
