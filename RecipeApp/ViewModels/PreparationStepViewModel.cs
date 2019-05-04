using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class PreparationStepViewModel
    {
        public PreparationStep NewStep { get; set; }
        public IEnumerable<PreparationStep> PreparationSteps { get; set; }

        public PreparationStepViewModel()
        {
            PreparationSteps = new List<PreparationStep>();
        }
    }
}
