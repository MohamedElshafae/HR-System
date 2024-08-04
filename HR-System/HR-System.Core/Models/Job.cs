using System;
using System.Collections.Generic;

namespace HR_System.Core.Models;

public partial class Job
{
    public Guid Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
