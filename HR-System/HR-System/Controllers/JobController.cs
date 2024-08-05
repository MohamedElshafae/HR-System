using HR_System.Core.Interfaces;
using HR_System.Core.Models;
using HR_System.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService) =>
            _jobService = jobService;

        // GET: api/<JobController>
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobService.GetJobs();
            return Ok(jobs);
        }


        // POST api/<JobController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string jobTilte)
        {
            bool isSuccess = await _jobService.CreateJob(jobTilte);
            if (!isSuccess)
                return Conflict(new { Message = "This Job Is Exist" });
            return Ok("Job created successfully");
        }
    }
}
