using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataStore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("/api/cities")]
    public class CitiesController : Controller
    {
		ILogger<CitiesController> _logger;
		ICitiesDataStore _citiesDataStore;

		public CitiesController(ILogger<CitiesController> logger,
			ICitiesDataStore citiesDataStore)
		{
			_logger = logger;
			_citiesDataStore = citiesDataStore;
		}

        [HttpGet()]
        public IActionResult GetCities()
        {
			_logger.LogInformation($"{nameof(GetCities)} called");

            var cities = _citiesDataStore.Cities;
            return Ok(cities);
        }

        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(int id)
        {

            var city = _citiesDataStore.Cities
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
            if (city == null)
            {
                BadRequest();
            }

			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

            int newCityId = _citiesDataStore.Cities.Max(c => c.Id) + 1;

            var newCity = new CityGetModel
            {
                Id = newCityId,
                Name = city.Name,
                Description = city.Description,
                NumberOfPointsOfInterest = city.NumberOfPointsOfInterest
            };

            _citiesDataStore.Cities.Add(newCity);

            return CreatedAtRoute("GetCity", new { id = newCityId }, newCity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {

            var city = _citiesDataStore.Cities
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (city == null)
            {
                NotFound();
            }

            _citiesDataStore.Cities.Remove(city);

            return Accepted();
        }

        [HttpPut("{id}")]
        public IActionResult PutCity(int id, [FromBody] CityCreateModel cityModel)
        {
            if (cityModel == null)
            {
                BadRequest();
            }



            var city = _citiesDataStore.Cities
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (city == null)
            {
                NotFound();
            }

            var index = _citiesDataStore.Cities
                 .IndexOf(city);

            _citiesDataStore.Cities[index].Name = cityModel.Name;
            _citiesDataStore.Cities[index].Description = cityModel.Description;
            _citiesDataStore.Cities[index].NumberOfPointsOfInterest = cityModel.NumberOfPointsOfInterest;

            return Ok(cityModel);

        }

        [HttpPatch("{id}")]
        public IActionResult PatchCity(int id, [FromBody] CityGetModel cityModel)
        {
            if (cityModel == null)
            {
                BadRequest();
            }



            var city = _citiesDataStore.Cities
               .Where(x => x.Id == id)
               .FirstOrDefault();

            if (city == null)
            {
                NotFound();
            }

            var index = _citiesDataStore.Cities
                 .IndexOf(city);

            var patch = new JsonPatchDocument();

            if (!string.IsNullOrEmpty(cityModel.Name))
                patch.Replace(nameof(cityModel.Name), cityModel.Name);

            if (!string.IsNullOrEmpty(cityModel.Description))
                patch.Replace(nameof(cityModel.Description), cityModel.Description);

            if (cityModel.NumberOfPointsOfInterest != _citiesDataStore.Cities[index].NumberOfPointsOfInterest)
                patch.Replace(nameof(cityModel.NumberOfPointsOfInterest), cityModel.NumberOfPointsOfInterest);

            patch.ApplyTo(_citiesDataStore.Cities[index]);



            return Ok(_citiesDataStore.Cities[index]);
        }
    }
}
