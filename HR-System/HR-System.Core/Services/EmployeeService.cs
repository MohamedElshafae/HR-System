using HR_System.Core.Interfaces;
using HR_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(Guid departmentId)
        {

            return await _employeeRepository.GetEmployeesByDepartmentAsync(departmentId);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            await _employeeRepository.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateEmployeeAsync(employee);
            await _employeeRepository.SaveChangesAsync();

        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            await _employeeRepository.SaveChangesAsync();
        }
    }
}

