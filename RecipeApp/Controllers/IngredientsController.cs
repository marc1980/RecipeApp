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
    public class IngredientsController : Controller
    {
        private readonly RecipeContext _context;

        public IngredientsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: Ingredients/Create
        public IActionResult Create(int recipeId)
        {
            var ingredientViewModel = new IngredientViewModel();
            ingredientViewModel.NewIngredient = new Ingredient() { RecipeId = recipeId };
            return View(ingredientViewModel);

        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( IngredientViewModel ingredientViewModel)
        {
            if (ModelState.IsValid)
            {
                var recipeId = ingredientViewModel.NewIngredient.RecipeId;

                _context.Add(ingredientViewModel.NewIngredient);
                await _context.SaveChangesAsync();

                ModelState.Clear();
                var Model = new IngredientViewModel();
                Model.NewIngredient = new Ingredient() { RecipeId = recipeId };
                Model.Ingredients = await _context.Ingredients
                    .Where( i => i.RecipeId == recipeId)
                    .ToListAsync();
                return View(Model);
            }
            return View();
        }

        //// GET: Ingredients/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ingredient = await _context.Ingredients
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ingredient == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ingredient);
        //}

        // POST: Ingredients/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ingredient = await _context.Ingredients.FindAsync(id);
        //    _context.Ingredients.Remove(ingredient);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
