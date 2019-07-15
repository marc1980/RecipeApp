using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Data;

namespace RecipeApp.Models
{
    public class RecipesController : Controller
    {
        private readonly RecipeContext _context;

        public RecipesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Where(m => m.Id == id)
                .Include(m => m.Ingredients)
                .Include(m => m.Steps)
                .Include(m => m.Reviews)
                .FirstOrDefaultAsync();
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();

                return RedirectToAction("List", "Ingredients", new { RecipeId = recipe.Id} );
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Where(m => m.Id == id)
                .Include(m => m.Ingredients)
                .Include(m => m.Steps)
                .FirstOrDefaultAsync();
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }


        // POST: Recipes/Delete/5
        [HttpPost]
       // [ValidateAntiForgeryToken]    
       // TODO: Fix token
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _context.Recipes
                .Where(m => m.Id == id)
                .Include(m => m.Ingredients)
                .Include(m => m.Steps)
                .Include(m => m.Reviews)
                .FirstOrDefaultAsync();
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            if(_context.Recipes.Any(r => r.Id == review.RecipeId))
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                var reviews = _context.Reviews.Where(r => r.RecipeId == review.RecipeId);
                return PartialView("~/Views/Recipes/_ReviewList.cshtml", reviews);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json( "Error: Recipe not found" );
            }
        }
        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
