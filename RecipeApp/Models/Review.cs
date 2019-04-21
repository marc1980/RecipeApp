using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Reviewer { get; set; }
        public string Body { get; set; }
    }
}
