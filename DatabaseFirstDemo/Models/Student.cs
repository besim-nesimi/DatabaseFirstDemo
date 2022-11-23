using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int HouseId { get; set; }

    public virtual ICollection<Familiar> Familiars { get; } = new List<Familiar>();

    public virtual House House { get; set; } = null!;
}
