using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class SQuery2Input
{
    [DisplayName("Номер готелю")]
    [Required(ErrorMessage = "Введіть номер готелю")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер готелю має бути додатній")]
    public int HotelNumber { get; set; }

    [DisplayName("Позиція в компанії")]
    [Required(ErrorMessage = "Введіть позицію в компанії")]
    public string PositionName { get; set; } = null!;
}
