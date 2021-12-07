using Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data.Models.Nomenclature;
using Mystore.Api.Repositories.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Controllers
{
    public class NomenclatureController : ApiController
    {
        private readonly ICityRepository cityRepository;
        private readonly IUnitOfMeasurementRepository unitOfMeasurementRepository;

        public NomenclatureController(
            ICityRepository cityRepository,
            IUnitOfMeasurementRepository unitOfMeasurementRepository)
        {
            this.cityRepository = cityRepository;
            this.unitOfMeasurementRepository = unitOfMeasurementRepository;
        }

        [HttpGet]
        [Route(nameof(GetCities))]
        public async Task<ActionResult<IList<City>>> GetCities()
        {
            var cities = await cityRepository.GetAll().ToListAsync();
            if (!cities.Any())
            {
                return BadRequest("No cities found in database.");
            }
            return Ok(cities);
        }

        [HttpPost]
        [Route(nameof(SaveCity))]
        public async Task<ActionResult> SaveCity(CityInputModel city)
        {
            await cityRepository.SaveAsync(new City { Name = city.Name });
            return Ok($"{city.Name} saved successfully.");
        }

        [HttpGet]
        [Route(nameof(GetUnits))]
        public async Task<ActionResult<IList<UnitOfMeasurement>>> GetUnits()
        {
            var units = await unitOfMeasurementRepository.GetAll().ToListAsync();
            if (!units.Any())
            {
                return BadRequest("No units of measurement found in database.");
            }
            return Ok(units);
        }

        [HttpPost]
        [Route(nameof(SaveUnit))]
        public async Task<ActionResult> SaveUnit(UnitOfMeasurementInputModel unit)
        {
            await unitOfMeasurementRepository.SaveAsync(new UnitOfMeasurement { Description = unit.Description });
            return Ok($"{unit.Description} saved successfully.");
        }
    }
}
