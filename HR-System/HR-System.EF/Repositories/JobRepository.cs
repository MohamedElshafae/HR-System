using HR_System.Core.Interfaces;
using HR_System.Core.Models;
using HR_System.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.EF.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly HrContext _context;
        public JobRepository(HrContext context) =>
            _context = context;
        public async Task CreateJob(Job job)
        {
            await _context.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Job>> GetJobs() =>
            _context.Jobs;

        public Task<bool> isExist(string jobTitle) =>
            _context.Jobs.AnyAsync(j => j.JobTitle == jobTitle);
    }
}
