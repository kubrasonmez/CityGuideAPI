using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.DTO;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper; 
        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        public ActionResult GetCities()
        {
            var cities = _appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDTO>>(cities);

            return Ok(citiesToReturn);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.saveAll();
            return Ok(city);
        }
        [Route("detail")]
        public ActionResult GetCities(int id)
        {
            var city = _appRepository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDTO>(city);

            return Ok(cityToReturn);
        }

        [HttpGet]
        [Route("photos")]
        public ActionResult GetPhotosByCity(int cityId)
        {
            var photos = _appRepository.GetPhotosByCity(cityId);
            return Ok(photos);
        }
    }
}