using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Data;

public partial class CompanyPosition
{
    [DisplayName("ID")]
    [Required(ErrorMessage = "Введіть ID")]
    [Range(1, int.MaxValue, ErrorMessage = "ID має бути додатній")]
    public int Id { get; set; }

    [DisplayName("Назва")]
    [Required(ErrorMessage = "Введіть назву")]
    public string Name { get; set; } = null!;

    [DisplayName("Ставка")]
    [Required(ErrorMessage = "Введіть ставку")]
    [Range(0, 1, ErrorMessage = "Введіть дійсне число від 0 до 1")]
    public float WorkingRate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
