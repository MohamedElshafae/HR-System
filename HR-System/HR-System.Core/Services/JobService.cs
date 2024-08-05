using HR_System.Core.Interfaces;
using HR_System.Core.Models;
using HR_System.Core.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository) =>
            _jobRepository = jobRepository;
        public async Task<bool> CreateJob(string JobTitle)
        {
            if (await _jobRepository.isExist(JobTitle))
                return false;
            var job = new Job()
            {
                Id = Guid.NewGuid(),
                JobTitle = JobTitle
            };
            _jobRepository.CreateJob(job);
            return true;
        }

        public Task<IEnumerable<Job>> GetJobs() =>
            _jobRepository.GetJobs();
    }
}
