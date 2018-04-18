using AmberAndGrain.Services;
using AmberAndGraing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmberAndGraing.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
			var repo = new RecipeRepository();
			var recipes = repo.GetAll();

            return View(recipes);
        }

		//Get: Recipe/Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		//Post: Recipe Create
		[HttpPost]
		public ActionResult Create(RecipeDto recipe)
		{
			var repo = new RecipeRepository();
			repo.Create(recipe);

			return RedirectToAction("Index");
		}

		//Get: recipe/edit/1
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var repo = new RecipeRepository();
			RecipeDto recipe = repo.Get(id);

			if(recipe == null)
			{
				return this.HttpNotFound("The recipe you requested does not exist.");
			}
			return View(recipe);

		}

		[HttpPost]
		public ActionResult Edit(int id, RecipeDto recipe)
		{
			if (!ModelState.IsValid)
			{
				return View(recipe);
			}

			var repo = new RecipeRepository();
			repo.Update(id, recipe);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Details(int id)
		{
			var repo = new RecipeRepository();
			var recipe = repo.Get(id);

			return View(recipe);
		}

    }
}