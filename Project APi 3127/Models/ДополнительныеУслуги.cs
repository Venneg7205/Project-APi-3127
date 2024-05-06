using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class ДополнительныеУслуги
{
    public int IdУслуги { get; set; }

    public string? Наименование { get; set; }

    public string? Описание { get; set; }

    public decimal? Цена { get; set; }
}
