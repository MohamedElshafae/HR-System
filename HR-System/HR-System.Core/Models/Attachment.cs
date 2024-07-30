using System;
using System.Collections.Generic;

namespace HR_System.Core.Models;

public partial class Attachment
{
    public int AttachmentId { get; set; }

    public DateTime? UploadedDate { get; set; }

    public string? FilePath { get; set; }

    public int? EmployeeId { get; set; }

    public int? AttachmentTypeId { get; set; }

    public virtual AttachmentsType? AttachmentType { get; set; }

    public virtual Employee? Employee { get; set; }
}
