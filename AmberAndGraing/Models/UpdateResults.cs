using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmberAndGraing.Models
{
	public class UpdateResults
	{
		public enum UpdateStatusResults
		{
			NotFound,
			Success,
			Unsuccessful,
			ValidationFailure
		}
	}
}