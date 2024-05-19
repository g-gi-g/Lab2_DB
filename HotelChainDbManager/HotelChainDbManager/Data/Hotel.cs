using System;
using System.Collections.Generic;

namespace HotelChainDbManager.Data;

public partial class Hotel
{
    public int Number { get; set; }

    public string Adress { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
