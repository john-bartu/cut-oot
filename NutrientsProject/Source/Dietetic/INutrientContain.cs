using System.Collections.Generic;

namespace NutrientsProject.Source
{
    public interface INutrientContain
    {
        public Dictionary<Nutrient, double> GetNutrients();
    }
}