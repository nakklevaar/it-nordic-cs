using Microsoft.AspNetCore.JsonPatch;
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
    public class CitiesController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            var cities = citiesDataStore.Cities;
            return Ok(cities);
        }
        [HttpGet("{id}", Name = "GetCity")]
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
        public IActionResult CreateCity([FromBody] CityGetModel city)
        {
            if (city == null)
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

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            var city = citiesDataStore.Cities
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (city == null)
            {
                NotFound();
            }

            citiesDataStore.Cities.Remove(city);

            return Accepted();
        }

        [HttpPut("{id}")]
        public IActionResult PutCity(int id, [FromBody] CityCreateModel cityModel)
        {
            if (cityModel == null)
            {
                BadRequest();
            }

            var citiesDataStore = CitiesDataStore.GetInstance();

            var city = citiesDataStore.Cities
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (city == null)
            {
                NotFound();
            }

            var index = citiesDataStore.Cities
                 .IndexOf(city);

            citiesDataStore.Cities[index].Name = cityModel.Name;
            citiesDataStore.Cities[index].Description = cityModel.Description;
            citiesDataStore.Cities[index].NumberOfPointsOfInterest = cityModel.NumberOfPointsOfInterest;

            return Ok(cityModel);

        }

        [HttpPatch("{id}")]
        public IActionResult PatchCity(int id, [FromBody] CityGetModel cityModel)
        {
            if (cityModel == null)
            {
                BadRequest();
            }

            var citiesDataStore = CitiesDataStore.GetInstance();

            var city = citiesDataStore.Cities
               .Where(x => x.Id == id)
               .FirstOrDefault();

            if (city == null)
            {
                NotFound();
            }

            var index = citiesDataStore.Cities
                 .IndexOf(city);

            var patch = new JsonPatchDocument();

            if (!string.IsNullOrEmpty(cityModel.Name))
                patch.Replace(nameof(cityModel.Name), cityModel.Name);

            if (!string.IsNullOrEmpty(cityModel.Description))
                patch.Replace(nameof(cityModel.Description), cityModel.Description);

            if (cityModel.NumberOfPointsOfInterest != citiesDataStore.Cities[index].NumberOfPointsOfInterest)
                patch.Replace(nameof(cityModel.NumberOfPointsOfInterest), cityModel.NumberOfPointsOfInterest);

            patch.ApplyTo(citiesDataStore.Cities[index]);



            return Ok(citiesDataStore.Cities[index]);
        }
    }
}
