using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace StructuralMechanics.Utilities
{
    public static class EnumDisplayHelper
    {
        public static string GetDisplayName(Enum value)
        {
            return value.GetType()?
           .GetMember(value.ToString())?.First()?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }
    }
}
