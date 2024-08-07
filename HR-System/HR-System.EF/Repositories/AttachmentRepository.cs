using HR_System.Core.Interfaces;
using HR_System.Core.Models;
using HR_System.Core.Services;
using HR_System.EF.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.EF.Repositories
{
    public class AttachmentRepository: IAttachmentRepository
    {
        private readonly HrContext _context;
        public AttachmentRepository(HrContext context) =>
            _context = context;

        public async Task CreateAttachmentAsync(Attachment attachment)
        {
            _context.Attachments.Add(attachment);
            await _context.SaveChangesAsync();
        }

    }
}
