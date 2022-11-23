using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo.Models;

public partial class Familiar
{
    public int FamiliarId { get; set; }

    public string Name { get; set; } = null!;

    public string AnimalType { get; set; } = null!;

    public int StudentId { get; set; }

    public virtual Student Student { get; set; } = null!;
}
