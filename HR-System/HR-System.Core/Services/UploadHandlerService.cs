using HR_System.Core.DTOs;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace HR_System.Core.Services
{
    public static class UploadHandlerService
    {
        public async static Task<FileHandlerDtos> UploadFileAsync(IFormFile file, string empName, Guid empId, FileType fileType)
        {
            string empDir = $"{empName}_{empId}";
            string fileName = $"{empName}_{empId}_{fileType}{Path.GetExtension(file.FileName)}";
            string folederPath = Path.Combine(Directory.GetCurrentDirectory(), "Attachments", empDir);
            var fileHandlerDto = new FileHandlerDtos()
            {
                IsSuccess = false
            };
            if (!Directory.Exists(folederPath))
                Directory.CreateDirectory(folederPath);

            var filePath = Path.Combine(folederPath, fileName);

            if (File.Exists(filePath))
            {
                fileHandlerDto.Message = "The file is already exist";
                return fileHandlerDto;
            }

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await file.CopyToAsync(stream);
            }
            catch (Exception ex)
            {
                fileHandlerDto.Message = ex.Message;
                return fileHandlerDto;
            }
            fileHandlerDto.IsSuccess = true;
            fileHandlerDto.filePath = filePath;
            return fileHandlerDto;
        }
        public static bool IsBigger(IFormFile file)
        {
            long size = file.Length;
            long MaxmumSize = 8 * 1024 * 1024;
            if (size > MaxmumSize)
                return true;
            return false;
        }
    }

    public enum FileType
    {
        CV,
        Img,
        txt,
        PDF,
        docx
    }
}
