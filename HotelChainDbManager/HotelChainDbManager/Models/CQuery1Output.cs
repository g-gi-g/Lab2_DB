using System.ComponentModel;

namespace HotelChainDbManager.Models;

public class CQuery1Output
{
    [DisplayName("Номер кімнати")]
    public int RoomNumber { get; set; }

    [DisplayName("Номер готелю")]
    public int HotelNumber { get; set; }
}
