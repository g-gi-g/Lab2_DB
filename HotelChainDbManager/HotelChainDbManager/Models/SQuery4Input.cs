using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class SQuery4Input
{
    [DisplayName("Адреса")]
    [Required(ErrorMessage = "Введіть адресу")]
    public string Address { get; set; } = null!;
}
