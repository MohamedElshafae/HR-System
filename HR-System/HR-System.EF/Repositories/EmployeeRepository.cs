using HR_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_System.EF.Data;
using HR_System.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_System.EF.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrContext _context;

        public EmployeeRepository(HrContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employees
                                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                                 .ToListAsync();
                                  
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(Guid departmentId)
        {
            return  _context.Employees
                                 .Where(e => e.DepartmentId == departmentId)
                                 .ToList();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
             _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

