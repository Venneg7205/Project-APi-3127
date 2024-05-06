using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class Автомобили
{
    public int IdАвтомобиля { get; set; }

    public int? IdМарки { get; set; }

    public string? ГосНомер { get; set; }

    public string? НомерКузова { get; set; }

    public string? НомерДвигателя { get; set; }

    public int? Год { get; set; }

    public int? Пробег { get; set; }

    public decimal? Цена { get; set; }

    public decimal? ЦенаПроката { get; set; }

    public DateTime? ДатаПоследнегоТо { get; set; }

    public int? IdМеханика { get; set; }

    public string? Особенности { get; set; }

    public bool? ОтметкаОвозврате { get; set; }
}
