using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_System.Core.Interfaces;
using HR_System.Core.Models;

namespace HR_System.Core.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task CreateDepartmentAsync(string departmentName)
        {
            //if (await _departmentRepository.DepartmentExistsAsync(departmentName))
            //{
            //    throw new InvalidOperationException("Department with the same name already exists ");
            //}

            var department = new Department()
            {
                Id = Guid.NewGuid(),
                DepartmentName = departmentName,
            };
            await _departmentRepository.AddDepartmentAsync(department);
            await _departmentRepository.SaveChangesAsync();
        }
        public async Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }
        public async Task<Department> GetDepartmentByNameAsync(string departmentName)
        {
            return await _departmentRepository.GetDepartmentByNameAsync(departmentName);
        }

    }
}
    

