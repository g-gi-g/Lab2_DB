using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelChainDbManager.Data;

public partial class Resident
{
    [DisplayName("ID-картка резидента")]
    [Required(ErrorMessage = "Введіть номер ID-картки")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер ID-картки має бути додатній")]
    public int IdCardNumber { get; set; }

    [DisplayName("Ім'я")]
    [Required(ErrorMessage = "Введіть ім'я")]
    public string Name { get; set; } = null!;

    [DisplayName("Прізвище")]
    [Required(ErrorMessage = "Введіть прізвище")]
    public string Surname { get; set; } = null!;

    [DisplayName("По-батькові")]
    public string? Patronimic { get; set; }

    [DisplayName("Дата народження")]
    [Required(ErrorMessage = "Введіть дату народження")]
    public DateOnly DateOfBirth { get; set; }

    [DisplayName("Стать")]
    [Required(ErrorMessage = "Введіть стать")]
    public string Gender { get; set; } = null!;

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
}
