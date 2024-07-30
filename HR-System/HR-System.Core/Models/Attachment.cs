using System;
using System.Collections.Generic;

namespace HR_System.Core.Models;

public partial class Attachment
{
    public int AttachmentId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? UploadDate { get; set; }

    public string? FilePath { get; set; }

    public int? EmployeeId { get; set; }

    public int? TypeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual AttachmentType? Type { get; set; }
}
