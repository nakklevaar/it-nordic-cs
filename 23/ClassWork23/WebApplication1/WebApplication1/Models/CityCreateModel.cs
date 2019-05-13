using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Validation;

namespace WebApplication1.Models
{
	public class CityCreateModel
	{
		[Required]
		[MaxLength(100, ErrorMessage = "The name of the city shouldnt be longer than 100 characters")]
		public string Name { get; set; }

		[MaxLength(100, ErrorMessage = "Description should be not longer than 255 characters")]
		[DifferentValueAttributte(OtherProperty = "Name")]
		public string Description { get; set; }

		[RangeAttribute(0, 100)]
		public int NumberOfPointsOfInterest { get; set; }
	}
}
