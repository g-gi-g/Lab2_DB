using System;
using System.Collections.Generic;

namespace HotelChainDbManager.Data;

public partial class Employee
{
    public int IdCardNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronimic { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public int CompanyPosition { get; set; }

    public int HotelNumber { get; set; }

    public virtual CompanyPosition CompanyPositionNavigation { get; set; } = null!;

    public virtual Hotel HotelNumberNavigation { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
