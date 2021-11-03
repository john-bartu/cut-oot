using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NutrientsProject.Source
{
    public class Product:INutrientContain
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public ICollection<ProductNutrient> ProductNutrients{ get; set; }

        public Dictionary<Nutrient, double> GetNutrients()
        {
            throw new NotImplementedException();
        }
    }
}
