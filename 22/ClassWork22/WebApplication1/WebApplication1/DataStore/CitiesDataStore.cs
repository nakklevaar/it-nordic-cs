using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DataStore
{
	public class CitiesDataStore
	{
		private static CitiesDataStore _store;

		public List<CityGetModel> Cities {get; private set;}

		private CitiesDataStore()
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

		public static CitiesDataStore GetInstance()
		{
			if (_store == null)
				_store = new CitiesDataStore();
			return _store;
		}
	}
}
