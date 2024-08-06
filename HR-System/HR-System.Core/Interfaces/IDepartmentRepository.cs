using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_System.Core.Models;

namespace HR_System.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentByIdAsync(Guid id);
        Task<Department?> GetDepartmentByNameAsync(string departmentName);

        Task<bool> DepartmentExistsAsync(Guid id);
        Task AddDepartmentAsync(Department department);
        Task SaveChangesAsync();
    }
}