using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class IngredientViewModel
    {
        public Ingredient NewIngredient { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IngredientViewModel()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
