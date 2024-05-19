using System;
using System.Collections.Generic;

namespace HotelChainDbManager.Data;

public partial class Room
{
    public int Number { get; set; }

    public int HotelNumber { get; set; }

    public int Class { get; set; }

    public int Capacity { get; set; }

    public virtual Class ClassNavigation { get; set; } = null!;

    public virtual Hotel HotelNumberNavigation { get; set; } = null!;

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
