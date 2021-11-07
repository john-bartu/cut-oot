using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace NutrientsProject.Source
{
    public class Product : INutrientContain
    {
        [Key] public int ProductID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductNutrient> ProductNutrients { get; set; }
        

        public Dictionary<Nutrient, double> GetNutrients()
        {
            var result = new Dictionary<Nutrient, double>();

            foreach (var nutrientInProduct in ProductNutrients)
            {
                result[nutrientInProduct.Nutrient] = nutrientInProduct.Amount;
            }

            return result;
        }
    }
}