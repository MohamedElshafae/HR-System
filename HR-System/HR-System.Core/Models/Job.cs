﻿using System;
using System.Collections.Generic;

namespace HR_System.Core.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
