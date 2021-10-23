using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.DAL.Models
{
    public enum Manufacture
    {
        [Description("Металлургический комбинат 'Азовсталь'")]
        Manufacturer_A,
        [Description("Новокузнецкий металлургический комбинат")]
        Manufacturer_K,
        [Description("Нижнетагильский металлургический комбинат")]
        Manufacturer_T,
        [Description("Челябинский металлургический комбинат")]
        Manufacturer_Ch,
        [Description("Актюбинский рельсобалочный завод")]
        Manufacturer_AR      
    }
}
