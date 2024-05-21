using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class SQuery1Input
{
    [DisplayName("Номер кімнати")]
    [Required(ErrorMessage = "Введіть номер кімнати")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер кімнати має бути додатній")]
    public int HotelNumber { get; set; }

    [DisplayName("Клас")]
    [Required(ErrorMessage = "Введіть клас")]
    public string ClassName { get; set; } = null!;
}