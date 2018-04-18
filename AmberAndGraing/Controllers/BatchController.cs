using AmberAndGrain.Services;
using AmberAndGraing.Models;
using AmberAndGraing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmberAndGraing.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch/Create
		[HttpGet]
        public ActionResult Create()
        {
			var recipes = new RecipeRepository().GetAll();
			var viewModel = new BatchDto { Recipes = recipes.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }) };
            return View(viewModel);
        }
		
		[HttpPost]
		public ActionResult Create(BatchDto addBatch)
		{
			new BatchRepository().Create(addBatch.RecipeId, addBatch.Cooker);

			return RedirectToAction("Create");

		}
    }
}