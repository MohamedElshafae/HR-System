using System;
using System.Collections.Generic;

namespace HR_System.Core.Models;

public partial class AttachmentsType
{
    public int AttachmentTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}
