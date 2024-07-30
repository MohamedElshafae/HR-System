using System;
using System.Collections.Generic;

namespace HR_System.Core.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Gender { get; set; }

    public int? JobId { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public int? DepartmentId { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Job? Job { get; set; }

    public virtual Employee? Manager { get; set; }
}
