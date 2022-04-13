namespace StructuralMechanics.Utilities
{
    public static class ModelValidationExtensions
    {
        public static bool IsPointValid(this Point point)
        {
            if (point.X < 0 || point.Y < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
