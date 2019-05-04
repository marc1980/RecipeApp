using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Data;
using RecipeApp.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.Controllers
{
    public class PreparationStepsController : Controller
    {
        private readonly RecipeContext _context;

        public PreparationStepsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: PreparationSteps/List
        public async Task<IActionResult> List(int recipeId)
        {
            var PreparationStepViewModel = new PreparationStepViewModel();
            PreparationStepViewModel.PreparationSteps = await _context.PreparationSteps
                    .Where( i => i.RecipeId == recipeId)
                    .ToListAsync();
            PreparationStepViewModel.NewStep = new PreparationStep() { RecipeId = recipeId };
            return View("Change",PreparationStepViewModel);

        }

        // POST: PreparationSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PreparationStepViewModel PreparationStepViewModel)
        {
            if (ModelState.IsValid)
            {
                var recipeId = PreparationStepViewModel.NewStep.RecipeId;

                _context.Add(PreparationStepViewModel.NewStep);
                await _context.SaveChangesAsync();

                return RedirectToAction("List",new { recipeId = recipeId });
            }
            return View();
        }

        // POST: PreparationSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int recipeId)
        {
            var PreparationStepToDelete = await _context.PreparationSteps.FindAsync(id);
            _context.PreparationSteps.Remove(PreparationStepToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction("List",new { recipeId = recipeId });
        }

        private bool PreparationStepExists(int id)
        {
            return _context.PreparationSteps.Any(e => e.Id == id);
        }
    }
}
