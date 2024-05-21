using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelChainDbManager.Models;

public class SQuery4Output
{
    [DisplayName("Номер ID-картки")]
    public int IdCardNumber { get; set; }

    [DisplayName("Ім'я")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Прізвище")]
    public string Surname { get; set; } = string.Empty;
}
