using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NutrientsProject.Source
{
    public class NutrientProduct
    {
        [Key]
        public int NIPID { get; set; }


        public int NutrientID { get; set; }
        [ForeignKey("NutrientID")]
        public virtual Nutrient Nutrient{ get; set; }


        public int ProductID { get; set; }
        [ForeignKey("ProductID")][JsonIgnore]
        public virtual Product Product{ get; set; }


        public double Amount { get; set; }
        
    }
}
