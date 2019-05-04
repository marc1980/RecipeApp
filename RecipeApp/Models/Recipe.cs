using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<PreparationStep> Steps { get; set; }
        public IEnumerable<Review> Reviews { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<PreparationStep>();
            Reviews = new List<Review>();
        }
    }
}
