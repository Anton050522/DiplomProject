using System.ComponentModel;

namespace RailDBProject.Model
{
    public enum Qualification
    {
        [Description("Оператор дефектоскопной тележки 4-го разряда")]
        qualif_4 = 4,
        [Description("Оператор дефектоскопной тележки 5-го разряда")]
        qualif_5 = 5,
        [Description("Оператор дефектоскопной тележки 6-го разряда")]
        qualif_6 = 6,
        [Description("Оператор дефектоскопной тележки 7-го разряда")]
        qualif_7 = 7,
    }
}
