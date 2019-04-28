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

        // GET: Ingredients/List
        public async Task<IActionResult> List(int recipeId)
        {
            var ingredientViewModel = new IngredientViewModel();
            ingredientViewModel.Ingredients = await _context.Ingredients
                    .Where( i => i.RecipeId == recipeId)
                    .ToListAsync();
            ingredientViewModel.NewIngredient = new Ingredient() { RecipeId = recipeId };
            return View("Change",ingredientViewModel);

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

                return RedirectToAction("List",new { recipeId = recipeId });
            }
            return View();
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int recipeId)
        {
            var ingredientToDelete = await _context.Ingredients.FindAsync(id);
            _context.Ingredients.Remove(ingredientToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction("List",new { recipeId = recipeId });
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
