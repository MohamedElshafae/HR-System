using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
namespace HR_System.Core.Services
{
    public enum FileType
    {
        CV,
        Img,
        txt,
        PDF,
        docx
    }
    public static class UploadHandlerService
    {
        public async static Task<bool> UploadFileAsync(IFormFile file, string empName, string empId, FileType fileType)
        {
            string fileName = empName + "_" + empId + "_" + fileType + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Attachments", fileName);

            if (File.Exists(filePath))
                return false;
            FileStream stream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);
            stream.Dispose();
            stream.Close();
            return true;
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
}
