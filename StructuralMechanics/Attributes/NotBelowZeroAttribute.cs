using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Attributes
{
    public class NotBelowZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null && (double)value >= 0)
                return true;
            return false;
        }
    }
}
