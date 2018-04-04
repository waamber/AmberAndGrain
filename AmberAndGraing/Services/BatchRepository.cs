using AmberAndGraing.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmberAndGraing.Services
{
	public class BatchRepository
	{
		public bool Create(int recipeId, string cooker)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString))
			{
				db.Open();
				var numberCreated = db.Execute(@"insert into batches(RecipeId, Cooker)
												values(@RecipeId, @Cooker)", new { recipeId, cooker });

				return numberCreated == 1;
			}
		}
	}
}