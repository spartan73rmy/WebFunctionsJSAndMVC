 //Antiguedad de alguna fecha a hoy

 string antiguedad = "";
    bool band = false;
    int dias_faltantes = 0;
    DateTime date_now = DateTime.Now;
    DateTime fecha_alta = Model.fecha_registro;

    if (!(fecha_alta.Year > date_now.Year && fecha_alta.Month > date_now.Month && fecha_alta.DayOfYear >= date_now.DayOfYear))
    {
        if (date_now.Year - fecha_alta.Year > 0)
        {
            antiguedad = "" + (date_now.Year - fecha_alta.Year);
            antiguedad += ((date_now.Year - fecha_alta.Year) > 1) ? " Años" : " Año";
            band = true;
            dias_faltantes = 365 - fecha_alta.DayOfYear;
        }

        if (date_now.DayOfYear - (fecha_alta.DayOfYear + dias_faltantes) > 0 || band)
        {
            if (band)
            {
                antiguedad += ", ";
                antiguedad += "" + (date_now.DayOfYear + dias_faltantes);
                antiguedad += ((date_now.DayOfYear + dias_faltantes) > 1) ? " Dias" : " Dia";
            }
            else
            {
                antiguedad += "" + (date_now.DayOfYear - fecha_alta.DayOfYear);
                antiguedad += ((date_now.DayOfYear - fecha_alta.DayOfYear) > 1) ? " Dias" : " Dia";
            }

        }
    }
    else { antiguedad = "0"; }
