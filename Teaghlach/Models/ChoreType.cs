using System.ComponentModel;
using System.Reflection;

namespace Teaghlach.Models
{
    public enum ChoreType
    {
        [Description("Empty Dishwasher")]
        EmptyDishwasher,

        [Description("Make Bed")]
        MakeBed,

        [Description("Clean Bedroom")]
        CleanBedroom,

        Vaccuuming,

        Polishing,

        [Description("Cut Grass")]
        CutGrass,

        [Description("Wash Car")]
        WashCar
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());

            var attr = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                             .FirstOrDefault() as DescriptionAttribute;

            return attr?.Description ?? value.ToString();
        }
    }


}
