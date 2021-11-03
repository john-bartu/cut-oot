using System.ComponentModel.DataAnnotations;

namespace NutrientsProject.Source
{
    public class Nutrient
    {
        [Key]
        public int NutrientID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        //back reference
        // public ICollection<NutrientProduct> NutrientProducts { get; set; }

    }
}
