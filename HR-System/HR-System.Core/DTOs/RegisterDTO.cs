using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.DTOs
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public Guid employeeId { get; set; }
        public string Email {  get; set; }
    }
}
