using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Models;

public class CQuery2Input
{
    [DisplayName("Номер ID-картки")]
    [Required(ErrorMessage = "Введіть номер ID-картки")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер ID-картки має бути додатній")]
    public int IdCardNumber { get; set; }
}
