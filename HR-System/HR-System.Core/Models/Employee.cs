using System;
using System.Collections.Generic;

namespace HR_System.Core.Models;

public partial class Employee
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? NationalId { get; set; }

    public Guid? DepartmentId { get; set; }

    public Guid? JobId { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public Guid? ManagerId { get; set; }

    public virtual AppUser? user { get; set; }
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }

    public virtual Job? Job { get; set; }


}
