using System;
using System.Collections.Generic;

namespace HotelChainDbManager.Data;

public partial class CompanyPosition
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public float WorkingRate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
