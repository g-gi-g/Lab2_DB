using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Data;

public partial class Rent
{
    [DisplayName("ID-картка резидента")]
    [Required(ErrorMessage = "Введіть номер ID-картки")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер ID-картки має бути додатній")]
    public int Resident { get; set; }

    [DisplayName("Номер")]
    [Required(ErrorMessage = "Введіть номер кімнати")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер кімнати має бути додатній")]
    public int RoomNumber { get; set; }

    [DisplayName("Номер готелю")]
    [Required(ErrorMessage = "Введіть номер готелю")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер готелю має бути додатній")]
    public int HotelNumber { get; set; }

    [DisplayName("Ціна за ніч")]
    [Required(ErrorMessage = "Введіть плату за ніч")]
    [Range(0, int.MaxValue, ErrorMessage = "Плата має бути невід'ємна")]
    public int CostPerDay { get; set; }

    [DisplayName("Дата початку оренди")]
    [Required(ErrorMessage = "Введіть дату початку оренди")]
    public DateOnly RentStart { get; set; }

    [DisplayName("Дата закінчення оренди")]
    [Required(ErrorMessage = "Введіть дату закінчення оренди")]
    public DateOnly RentEnd { get; set; }

    public virtual Resident ResidentNavigation { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
