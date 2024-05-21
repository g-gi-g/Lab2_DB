using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class CQuery3Input
{
    [DisplayName("Позиція в компанії")]
    [Required(ErrorMessage = "Введіть позицію")]
    public string PositionName { get; set; } = string.Empty;
}
