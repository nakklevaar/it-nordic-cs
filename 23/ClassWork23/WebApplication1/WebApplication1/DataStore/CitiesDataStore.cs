using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DataStore
{
	public class CitiesDataStore: ICitiesDataStore
	{

		public List<CityGetModel> Cities {get; private set;}

		public CitiesDataStore()
		{
			Cities = new List<CityGetModel>
			{
				new CityGetModel
				{
					Id = 1,
					Name = "Moscow",
					Description = "The capital of Russia"
				},

				new CityGetModel
				{
					Id = 2,
					Name = "New York",
					Description = "The one of the biggest city in the world"
				}
			};
		}


	}
}
