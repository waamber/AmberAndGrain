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

		[Route("{batchId}/mash"), HttpPatch]
		public HttpResponseMessage MashBatch(int batchId)
		{
			var batchMasher = new BatchMasher();
			var mashMe = batchMasher.MashBatch(batchId);

			switch (mashMe)
			{
				case UpdateStatusResults.NotFound:
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Batch ID does not exist.");

				case UpdateStatusResults.Unsuccessful:
					return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Batch could not be update, please try again.");

				case UpdateStatusResults.ValidationFailure:
					return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The batch is not valid, please try again.");

				case UpdateStatusResults.Success:
					return Request.CreateResponse(HttpStatusCode.OK);

				default:
					return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Batch could not be updated, please try again.");
			}
		}
	}
}