using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class Прокат
{
    public DateTime? ДатаПроката { get; set; }

    public int? ПериодПроката { get; set; }

    public DateTime? ДатаВозврата { get; set; }

    public int? IdАвтомобиля { get; set; }

    public int? IdКлиента { get; set; }

    public int? IdУслуги1 { get; set; }

    public int? IdУслуги2 { get; set; }

    public int? IdУслуги3 { get; set; }

    public decimal? ЦенаПроката { get; set; }

    public bool? ОтметкаОплате { get; set; }

    public int? IdСотрудника { get; set; }
}
