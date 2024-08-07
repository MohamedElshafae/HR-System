using HR_System.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HR_System.Core.Services
{
    public static class FileHandlerService
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

        public async static Task<FileDto> downloadFile(string path)
        {
            var fileDto = new FileDto()
            {
                isSuccess = false
            };
            var provider = new FileExtensionContentTypeProvider();

            if (!File.Exists(path))
                return fileDto;

            var memory = new MemoryStream();
            var contentType = provider.GetType();
            var bytes = await File.ReadAllBytesAsync(path);

            fileDto.isSuccess = true;
            fileDto.bytes = bytes;
            fileDto.contentType = contentType;
            fileDto.path = path;

            return fileDto;
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
