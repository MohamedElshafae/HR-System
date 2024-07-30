using System;
using System.Collections.Generic;

namespace HR_System.Core.Models;

public partial class AttachmentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}
