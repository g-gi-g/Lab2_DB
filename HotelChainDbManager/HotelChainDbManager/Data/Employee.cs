using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelChainDbManager.Data;

public partial class Employee
{
    [DisplayName("Номер ID-картки")]
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

    [DisplayName("Позиція в компанії")]
    [Required(ErrorMessage = "Введіть позицію в компанії")]
    public int CompanyPosition { get; set; }

    [DisplayName("Номер готелю")]
    [Required(ErrorMessage = "Введіть номер готелю")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер готелю має бути додатній")]
    public int HotelNumber { get; set; }

    public virtual CompanyPosition CompanyPositionNavigation { get; set; } = null!;

    public virtual Hotel HotelNumberNavigation { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
