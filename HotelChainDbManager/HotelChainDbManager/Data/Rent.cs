using System;
using System.Collections.Generic;

namespace HotelChainDbManager.Data;

public partial class Rent
{
    public int Resident { get; set; }

    public int RoomNumber { get; set; }

    public int HotelNumber { get; set; }

    public int CostPerDay { get; set; }

    public DateOnly RentStart { get; set; }

    public DateOnly RentEnd { get; set; }

    public virtual Resident ResidentNavigation { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
