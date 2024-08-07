using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HR_System.Core.DTOs;
using HR_System.Core.Services;
using System;
using System.Threading.Tasks;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly AttachmentService _attachmentService;

        public AttachmentsController(AttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        [HttpPost("create_attachment")]
        public async Task<IActionResult> CreateAttachment(IFormFile file, FileType fileType, Guid empId)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { Message = "No file uploaded " });
            }

            var result = await _attachmentService.CreateAttachmentAsync(file, fileType, empId);

            if (result.IsSuccess)
            {
                return Ok(new { Message = "File uploaded successfully.", FilePath = result.filePath });
            }
            else
            {
                return BadRequest(new { Message = result.Message });
            }
        }
    }
}
