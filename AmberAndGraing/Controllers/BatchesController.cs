using AmberAndGraing.Models;
using AmberAndGraing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmberAndGraing.Controllers
{
	[RoutePrefix("api/batches")]
	public class BatchesController : ApiController
	{
		[Route, HttpPost]
		public HttpResponseMessage AddBatch(BatchDto batch)
		{
			var repository = new BatchRepository();
			var result = repository.Create(batch.RecipeId, batch.Cooker);

			if (result)
			{
				return Request.CreateResponse(HttpStatusCode.Created);
			}
			return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Batch could not be created, try again.");

		}
	}
}