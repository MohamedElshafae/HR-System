using HR_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.ServicesInterfaces
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(AppUser user);
    }
}
