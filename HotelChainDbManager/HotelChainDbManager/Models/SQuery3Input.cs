using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class SQuery3Input
{
    [DisplayName("Клас")]
    [Required(ErrorMessage = "Введіть назву класу")]
    public string ClassName { get; set; } = null!;
}
