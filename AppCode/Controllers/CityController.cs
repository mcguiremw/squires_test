using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCode.Data.Entities;
using AppCode.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCode.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public Task<IEnumerable<City>> GetCities()
        {
            return _cityRepository.GetAll();
        }

        [HttpPost]
        public Task<bool> Add(City city)
        {
           return _cityRepository.Save(city);
        }

        [HttpDelete("{id}")]
        public bool Remove(int id)
        {
            var city= _cityRepository.Get(id).Result;
            return _cityRepository.Remove(city);
        }
    }
}
