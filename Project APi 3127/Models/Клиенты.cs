using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class Клиенты
{
    public int IdКлиента { get; set; }

    public string? Фио { get; set; }

    public string? Пол { get; set; }

    public DateTime? ДатаРождения { get; set; }

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public string? ПаспортныеДанные { get; set; }

    public decimal? Скидка { get; set; }
}
