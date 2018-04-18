using System.ComponentModel.DataAnnotations;

namespace AmberAndGraing.Models
{
	public class RecipeDto
	{
		[Display(Name="Name")]
		[MaxLength(200,ErrorMessage="Name cannot be more than 200 characters.")]
		[Required]
		public string Name { get; set; }

		[Display(Name="Percentage Wheat")]
		[Required]
		[Range(0,100)]
		public decimal PercentWheat { get; set; }

		[Display(Name = "Percentage Corn")]
		[Required]
		[Range(0, 100)]
		public decimal PercentCorn { get; set; }

		[Display(Name = "Barrel Age (Months)")]
		[Required]
		public int BarrelAge { get; set; }

		[Display(Name = "Barrel Material")]
		[Required]
		public string BarrelMaterial { get; set; }

		[Display(Name = "Recipe Creator")]
		[Required]
		public string Creator { get; set; }

		public int Id { get; set; }

	}
}