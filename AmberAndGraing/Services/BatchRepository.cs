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
		private static SqlConnection GetConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString);
		}

		public bool Create(int recipeId, string cooker)
		{
			using (var db = GetConnection())
			{
				db.Open();
				var numberCreated = db.Execute(@"insert into batches(RecipeId, Cooker)
												values(@RecipeId, @Cooker)", new { recipeId, cooker });

				return numberCreated == 1;
			}
		}

		public Batch Get(int batchId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				var getSingleBatch = db.QueryFirst<Batch>(@"select *
															from batches
															where Id = @batchId;", new { batchId });

				return getSingleBatch;
			}
		}

		public bool Update(Batch batch)
		{
			using (var db = GetConnection())
			{
				db.Open();
				var updateBatch = db.Execute(@"update batches
											   set [DateBarrelled] = @DateBarrelled
												  ,[NumberOfBarrels] = @NumberOfBarrels
												  ,[DateBottled] = @DateBottled
												  ,[NumberOfBottles] = @NumberOfBottles
												  ,[Cooker] = @Cooker
												  ,[PricePerBottle] = @PricePerBottle
												  ,[NumberOfBottlesLeft] = @NumberOfBottlesLeft
												  ,[Status] = @Status
												   where id = @Id", batch);

				return updateBatch == 1;
			}
		}
	}
}