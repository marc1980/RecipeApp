using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class PreparationStep
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int Rank { get; set; }
        public string Description { get; set; }
    }
}
