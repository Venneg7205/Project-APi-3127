using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class Автопарк
{
    public string? ГосНомер { get; set; }

    public string? Expr1 { get; set; }

    public string? Фио { get; set; }

    public string? Expr2 { get; set; }

    public string? Expr3 { get; set; }

    public string? НомерКузова { get; set; }

    public string? НомерДвигателя { get; set; }

    public int? Год { get; set; }

    public int? Пробег { get; set; }

    public decimal? Цена { get; set; }

    public DateTime? ДатаПоследнегоТо { get; set; }

    public string? Особенности { get; set; }
}
