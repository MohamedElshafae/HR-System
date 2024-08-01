using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_System.Core.Models;

public partial class Attachment
{
    public int AttachmentId { get; set; }

    public DateTime? UploadedDate { get; set; }

    public string? FilePath { get; set; }

    public int? EmployeeId { get; set; }

    [Required]
    public FileType FileType { get; set; }
    public virtual Employee? Employee { get; set; }
}
