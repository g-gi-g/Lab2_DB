using System;
using System.Collections.Generic;

namespace HotelChainDbManager.Data;

public partial class Resident
{
    public int IdCardNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronimic { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
}
