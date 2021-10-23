using System.ComponentModel;

namespace RailDBProject.Model
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
