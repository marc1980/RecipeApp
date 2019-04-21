using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public enum UnitOfMeasure
    {
        Piece,
        Gram,
        Miligram,
        Kilogram,
        Liter,
        Mililiter,
        Centiliter
    }
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public UnitOfMeasure Unit { get; set; }
    }
}
