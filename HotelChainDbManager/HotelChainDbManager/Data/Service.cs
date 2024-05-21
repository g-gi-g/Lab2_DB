using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelChainDbManager.Data;

public partial class Service
{
    [DisplayName("Номер ID-картки")]
    [Required(ErrorMessage = "Введіть номер ID-картки")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер ID-картки має бути додатній")]
    public int EmployeeId { get; set; }

    [DisplayName("Номер")]
    [Required(ErrorMessage = "Введіть номер кімнати")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер кімнати має бути додатній")]
    public int RoomNumber { get; set; }

    [DisplayName("Номер готелю")]
    [Required(ErrorMessage = "Введіть номер готелю")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер готелю має бути додатній")]
    public int HotelNumber { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
