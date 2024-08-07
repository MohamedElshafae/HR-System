using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace HR_System.Core.Services
{
    public static class UploadHandlerService
    {
        public async static Task<string> UploadFileAsync(IFormFile file, string empName, Guid empId, FileType fileType)
        {
            string empDir = $"{empName}_{empId}";
            string fileName = $"{empName}_{empId}_{fileType}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Attachments", empDir, fileName);

            if (File.Exists(filePath))
                return null;
            FileStream stream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);
            stream.Dispose();
            stream.Close();
            return filePath;
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
