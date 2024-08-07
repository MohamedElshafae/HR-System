using HR_System.Core.DTOs;
using HR_System.Core.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.ServicesInterfaces
{
    public interface IAttachmentService
    {
        Task<AttachmentDtos> CreateAttachmentAsync(IFormFile file, FileType fileType, Guid empId);
    }
}
