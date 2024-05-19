namespace HotelChainDbManager.Data;

public partial class Service
{
    public int EmployeeId { get; set; }

    public int RoomNumber { get; set; }

    public int HotelNumber { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
