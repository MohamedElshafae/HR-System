using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_System.Core.Services;
using HR_System.Core.Models;
using HR_System.EF.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using HR_System.Core.Interfaces;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(EmployeeService employeeService , IEmployeeRepository employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }


        [HttpGet("get-employee/{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return BadRequest(new { Message = "Employee not found " });
            }


            return Ok(employee);
        }

        [HttpGet("by_department/{departmentId}")]

        public async Task<IActionResult> GetEmployeesByDepartment(Guid departmentId)
        {
            var employees = await _employeeService.GetEmployeesByDepartmentAsync(departmentId);

            if (employees == null)
            {
                return BadRequest(new { Message = " Employees not exist in this department" });
            }
            else
            {
                return Ok(employees);
            }
        }


        [HttpPost("add_employee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null || string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName))
            {
                return BadRequest("Invalid employee data.");
            }

            var existingEmployee = await _employeeRepository.GetEmployeeByEmailAsync(employee.Email);
            if (existingEmployee != null)
            {
                return Conflict(new { Message = "this email already exists " });
            }


            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);

        }


        [HttpPut("update_employee/")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {

            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(employee.Id);
            if (existingEmployee == null)
            {
                return NotFound(new { Message = "Employee not found " });
            }
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.Attachments = employee.Attachments;
            existingEmployee.JobId = employee.JobId;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.ManagerId = employee.ManagerId;



            await _employeeService.UpdateEmployeeAsync(existingEmployee);
            return Ok();

        }

        [HttpDelete("delete /{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound(new { Message = "Employee not found." });
            }

            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
