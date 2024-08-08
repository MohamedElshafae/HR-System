using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HR_System.Core.DTOs;
using HR_System.Core.Services;
using System;
using System.Threading.Tasks;
using HR_System.Core.ServicesInterfaces;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;

        public AttachmentsController(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        [HttpPost("create_attachment")]
        public async Task<IActionResult> CreateAttachment(IFormFile file, FileType fileType, Guid empId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (file == null || file.Length == 0)
                return BadRequest(new { Message = "No file uploaded " });

            var result = await _attachmentService.CreateAttachmentAsync(file, fileType, empId);

            if (result.IsSuccess)
                return Ok(new { Message = "File uploaded successfully.", FilePath = result.filePath });

            return BadRequest(new { Message = result.Message });
        }

        [HttpGet("attachment")]
        public async Task<IActionResult> GetAttachment(string path)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var fileDto = await FileHandlerService.downloadFile(path);

            if (!fileDto.isSuccess)
                return NotFound("fail");

            return File(fileDto.bytes, fileDto.contentType, "download");
        }
    }
}
