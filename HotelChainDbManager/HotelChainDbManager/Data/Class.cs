using System;
using System.Collections.Generic;

namespace HotelChainDbManager.Data;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
