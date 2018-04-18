using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AmberAndGraing.Models
{
	public class BatchDto
	{
		public IEnumerable<SelectListItem> Recipes { get; set; }
		public int RecipeId { get; set; }
		public string Cooker { get; set; }
	}
}