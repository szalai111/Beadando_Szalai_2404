using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Szalai_2404.Model
{
    [Table("ingredients")]
    class Ingredient
    {
        [Key]
        [Column("ingredientid")]

        public int Id { get; set; }

        [Column("ingredientname")]

        public string IngredientName { get; set; }

        [Column("ingredientamount")]

        public string Amount { get; set; }
    }
}
