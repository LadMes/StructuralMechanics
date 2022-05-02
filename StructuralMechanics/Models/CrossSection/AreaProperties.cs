using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.CrossSection
{
    public abstract class AreaProperties : CrossSectionElement
    {
        private double firstMomentOfArea;
        private double secondMomentOfArea;
        [Required]
        public double FirstMomentOfArea { get { return firstMomentOfArea; } protected set { firstMomentOfArea = Math.Round(value, 2); } }
        [Required]
        public double SecondMomentOfArea { get { return secondMomentOfArea; } protected set { secondMomentOfArea = Math.Round(value, 2); } }

        protected abstract void CalculateFirstMomentOfArea();
        protected abstract void CalculateSecondMomentOfArea();
    }
}
