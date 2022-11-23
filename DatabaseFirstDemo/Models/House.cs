using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo.Models;

public partial class House
{
    public int HouseId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
