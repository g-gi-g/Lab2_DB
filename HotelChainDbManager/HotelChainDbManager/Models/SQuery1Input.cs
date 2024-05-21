using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class SQuery1Input
{
    [DisplayName("Номер готелю")]
    [Required(ErrorMessage = "Введіть номер готелю")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер готелю має бути додатній")]
    public int HotelNumber { get; set; }

    [DisplayName("Клас")]
    [Required(ErrorMessage = "Введіть клас")]
    public string ClassName { get; set; } = null!;
}