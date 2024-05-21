using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class CQuery1Input
{
    [DisplayName("Номер кімнати")]
    [Required(ErrorMessage = "Введіть номер кімнати")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер кімнати має бути додатній")]
    public int RoomNumber { get; set; }

    [DisplayName("Номер готелю")]
    [Required(ErrorMessage = "Введіть номер")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер готелю має бути додатній")]

    public int HotelNumber { get; set; }
}
