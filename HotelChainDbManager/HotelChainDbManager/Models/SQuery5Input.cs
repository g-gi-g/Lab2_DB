using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class SQuery5Input
{
    [DisplayName("Ставка")]
    [Required(ErrorMessage = "Введіть ставку")]
    [Range(0, 1, ErrorMessage = "Введіть дійсне число від 0 до 1")]
    public double WorkingRate { get; set; }
}
