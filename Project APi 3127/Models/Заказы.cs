using System;
using System.Collections.Generic;

namespace Project_APi_3127.Models;

public partial class Заказы
{
    public int IdЗаказа { get; set; }

    public int IdКлиента { get; set; }

    public int IdАвтомобиля { get; set; }

    public DateTime ДатаЗаказа { get; set; }

    public TimeSpan ВремяЗаказа { get; set; }
}
