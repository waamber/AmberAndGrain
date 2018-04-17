﻿using AmberAndGraing.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static AmberAndGraing.Models.UpdateResults;

namespace AmberAndGraing.Services
{
	public class BatchMasher
	{
		public UpdateStatusResults MashBatch(int batchId)
		{
			var repository = new BatchRepository();
			Batch batch;

			try
			{
				batch = repository.Get(batchId);

			}
			catch (SqlException)
			{
				return UpdateStatusResults.Unsuccessful;
			}
			catch (Exception ex)
			{
				return UpdateStatusResults.NotFound;
			}


			if (batch.Status != BatchStatus.Created)
				return UpdateStatusResults.ValidationFailure;

			batch.Status = BatchStatus.Mashed;
			var result = repository.Update(batch);
			return result
				? UpdateStatusResults.Success
				: UpdateStatusResults.Unsuccessful;

		}
	}
}