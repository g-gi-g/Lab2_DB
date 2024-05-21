using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Data;

public partial class Class
{
    [DisplayName("ID")]
    [Required(ErrorMessage = "Введіть ID")]
    [Range(1, int.MaxValue, ErrorMessage = "ID має бути додатній")]
    public int Id { get; set; }

    [DisplayName("Назва")]
    [Required(ErrorMessage = "Введіть назву")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
