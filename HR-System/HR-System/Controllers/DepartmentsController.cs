using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using HR_System.Core.Models;
using HR_System.Core.Services;


namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("create_department")]
        public async Task<IActionResult> CreateDepartment([FromBody] string departmentName)
        {

            if (string.IsNullOrEmpty(departmentName))
            {
                return BadRequest(new { Message = "Department name cannot be empty " });
            }

            var existingDepartment = await _departmentService.GetDepartmentByNameAsync(departmentName);
            if (existingDepartment != null)
            {
                return Conflict(new { Message = "Department already exists " });
            }
            try
            {

                await _departmentService.CreateDepartmentAsync(departmentName);

                var newDepartment = await _departmentService.GetDepartmentByNameAsync(departmentName);
                return CreatedAtAction(nameof(GetDepartmentById), new { id = newDepartment?.Id }, newDepartment);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Message = ex.Message });
            }
        }


        [HttpGet("get_department/{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound(new { Message = "Department not found " });
            }

            return Ok(department);
        }
    }
}
