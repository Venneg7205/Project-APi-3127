using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class АвтомобилиВПрокате
{
    public DateTime? ДатаПроката { get; set; }

    public string? Наименование { get; set; }

    public string? ТехническиеХарактеристики { get; set; }

    public string? ГосНомер { get; set; }

    public string? Фио { get; set; }

    public string? Услуги1 { get; set; }

    public string? Услуги2 { get; set; }

    public string? Услуги3 { get; set; }

    public string? СотрудникиФио { get; set; }

    public string? Expr1 { get; set; }

    public int? Возраст { get; set; }

    public string? Пол { get; set; }

    public string? Телефон { get; set; }

    public string? ПаспортныеДанные { get; set; }
}
