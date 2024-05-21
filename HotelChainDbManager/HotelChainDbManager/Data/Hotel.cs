using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Data;

public partial class Hotel
{
    [DisplayName("Номер готелю")]
    [Required(ErrorMessage = "Введіть номер")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер готелю має бути додатній")]
    public int Number { get; set; }

    [DisplayName("Адреса")]
    [Required(ErrorMessage = "Введіть адресу")]
    public string Adress { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
