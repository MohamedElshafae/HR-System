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
        public async Task<FileHandlerDtos> CreateAttachmentAsync(IFormFile file, FileType fileType, Guid empId)
        {
            var fileHandlerDtos = await UploadFile(file, fileType, empId);

            if (fileHandlerDtos.IsSuccess)
            {
                Attachment attachment = new Attachment()
                {
                    Id = Guid.NewGuid(),
                    FilePath = fileHandlerDtos.filePath, 
                    EmployeeId = empId,
                    UploadedDate = DateTime.Now,
                    FileType = fileType,
                };

                _attachmentRepository.CreateAttachmentAsync(attachment);
            }

            return fileHandlerDtos;
        }

        private async Task<FileHandlerDtos> UploadFile(IFormFile file, FileType fileType, Guid empId)
        {
            FileHandlerDtos fileHandlerDtos = new FileHandlerDtos();
            fileHandlerDtos.IsSuccess = false;

            if (FileHandlerService.IsBigger(file))
            {
                fileHandlerDtos.Message = "The File is bigger than 5MB";
                return fileHandlerDtos;
            }
            var emp = await _employeeRepository.GetEmployeeByIdAsync(empId);

            if (emp == null)
            {
                fileHandlerDtos.Message = "emp Not Found";
                return fileHandlerDtos;
            }
            fileHandlerDtos = await FileHandlerService.UploadFileAsync(file, emp.FirstName, emp.Id, fileType);
            return fileHandlerDtos;
        }
    }
}
