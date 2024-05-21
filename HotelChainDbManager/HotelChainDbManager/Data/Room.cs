using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelChainDbManager.Data;

public partial class Room
{
    [DisplayName("Номер")]
    [Required(ErrorMessage = "Введіть номер кімнати")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер кімнати має бути додатній")]
    public int Number { get; set; }

    [DisplayName("Номер готелю")]
    [Required(ErrorMessage = "Введіть номер готелю")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер готелю має бути додатній")]
    public int HotelNumber { get; set; }

    [DisplayName("Клас")]
    [Required(ErrorMessage = "Введіть клас")]
    public int Class { get; set; }

    [DisplayName("Вмісткість")]
    [Required(ErrorMessage = "Введіть вмісткість")]
    [Range(1, int.MaxValue, ErrorMessage = "Вмісткість має бути додатня")]
    public int Capacity { get; set; }

    public virtual Class ClassNavigation { get; set; } = null!;

    public virtual Hotel HotelNumberNavigation { get; set; } = null!;

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
