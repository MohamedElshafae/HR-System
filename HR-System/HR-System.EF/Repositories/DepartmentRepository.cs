using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using HR_System.Core.Interfaces;
using HR_System.Core.Models;
using HR_System.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HrContext _context;

        public DepartmentRepository(HrContext context)
        {
            _context = context;
        }
        public async Task<bool> DepartmentExistsAsync(Guid id)
        {
            return await _context.Departments.AnyAsync(d => d.Id == id);
        }

        public async Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            return await _context.Departments.FindAsync(id);
        }
        public async Task<Department> GetDepartmentByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Department name cannot be null or empty.");
            }

            return await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentName == name);
        }



        public async Task AddDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}