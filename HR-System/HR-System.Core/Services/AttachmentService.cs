using HR_System.Core.DTOs;
using HR_System.Core.Interfaces;
using HR_System.Core.Models;
using HR_System.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public AttachmentService(IAttachmentRepository attachmentRepository, IEmployeeRepository employeeRepository)
        {
            _attachmentRepository = attachmentRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<AttachmentDtos> CreateAttachmentAsync(IFormFile file, FileType fileType, Guid empId)
        {
            var attachmentDtos = await UploadFile(file, fileType, empId);

            if (attachmentDtos.IsSuccess)
            {
                Attachment attachment = new Attachment()
                {
                    Id = Guid.NewGuid(),
                    FilePath = attachmentDtos.filePath, 
                    EmployeeId = empId,
                    UploadedDate = DateTime.Now,
                    FileType = fileType,
                };

                _attachmentRepository.CreateAttachmentAsync(attachment);
            }

            return attachmentDtos;
        }

        private async Task<AttachmentDtos> UploadFile(IFormFile file, FileType fileType, Guid empId)
        {
            AttachmentDtos attachmentDtos = new AttachmentDtos();
            attachmentDtos.IsSuccess = false;

            if (UploadHandlerService.IsBigger(file))
            {
                attachmentDtos.Message = "The File is bigger than 5MB";
                return attachmentDtos;
            }
            var emp = await _employeeRepository.GetEmployeeByIdAsync(empId);

            if (emp == null)
            {
                attachmentDtos.Message = "emp Not Found";
                return attachmentDtos;
            }
            var filePath = await UploadHandlerService.UploadFileAsync(file, emp.FirstName, emp.Id, fileType);
            if (filePath == null)
            {
                attachmentDtos.Message = "The File did not upload";
                return attachmentDtos;
            }
            attachmentDtos.IsSuccess = true;
            attachmentDtos.filePath = filePath;
            return attachmentDtos;
        }
    }
}
