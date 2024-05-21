using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelChainDbManager.Models;

public class CQuery3Output
{
    [DisplayName("Номер ID-картки")]
    public int IdCardNumber { get; set; }
}
