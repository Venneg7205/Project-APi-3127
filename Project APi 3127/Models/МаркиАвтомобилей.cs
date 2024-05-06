using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class МаркиАвтомобилей
{
    public int IdМарки { get; set; }

    public string? Наименование { get; set; }

    public string? ТехническиеХарактеристики { get; set; }

    public string? Описание { get; set; }
}
