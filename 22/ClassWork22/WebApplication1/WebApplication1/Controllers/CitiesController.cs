using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataStore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Route("/api/cities")]
	public class CitiesController: Controller
	{
		[HttpGet()]
		public IActionResult GetCities()
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			var cities = citiesDataStore.Cities;
				return Ok(cities);
		}
		[HttpGet("{id}")]
		public IActionResult GetCity(int id)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			var city = citiesDataStore.Cities
				.Where(x => x.Id == id)
				.FirstOrDefault();

			if (city == null)
			{
				return NotFound();
			}

			return Ok(city);
		}

		[HttpPost()]
		public IActionResult CreateCity([FromBody] CityCreateModel city)
		{
			if(city==null)
			{
				BadRequest();
			}

			var citiesDataStore = CitiesDataStore.GetInstance();
			int newCityId = citiesDataStore.Cities.Max(c => c.Id) + 1;

			var newCity = new CityGetModel
			{
				Id = newCityId,
				Name = city.Name,
				Description = city.Description,
				NumberOfPointsOfInterest = city.NumberOfPointsOfInterest
			};

			citiesDataStore.Cities.Add(newCity);

			return CreatedAtRoute("GetCity", new { id = newCityId }, newCity);
		}
	}
}
