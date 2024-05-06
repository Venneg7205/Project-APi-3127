using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class Сотрудники
{
    public int IdСотрудника { get; set; }

    public string? Фио { get; set; }

    public int? Возраст { get; set; }

    public string? Пол { get; set; }

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public string? ПаспортныеДанные { get; set; }

    public int? IdДолжности { get; set; }
}
