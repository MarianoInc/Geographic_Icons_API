using Geographic_Icons_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Geographic_Icons_API.Controllers
{
    [Route("api/cities")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CityController : ControllerBase
    {//Inyección de dependencia.
        protected readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        //Obtener entidades
        [HttpGet]
        public IActionResult Get(int? continent, string name = "")
        {
            var selectMethod = _cityRepository.GetAllEntities();

            if (!String.IsNullOrEmpty(name))
            {
                selectMethod = selectMethod.Where(city => city.CityName.ToUpper() == name.ToUpper())
                                        .Select(city => new City{
                                            CityPicture = city.CityPicture,
                                            CityName = city.CityName,
                                            Population = city.Population
                                        })
                                        .ToList();
            }
            else if (continent.HasValue)
            {
                selectMethod = selectMethod.Where(city => city.ContinentId == continent)
                                        .Select(city => new City{
                                            CityPicture = city.CityPicture,
                                            CityName = city.CityName,
                                            Population = city.Population
                                        })
                                        .ToList();
            }
            else
            {
                selectMethod = selectMethod.Select(city => new City{
                    CityPicture = city.CityPicture,
                    CityName = city.CityName,
                    Population = city.Population
                }).ToList();
            }

            return Ok(selectMethod);
        }

        //Obtener detalles
        [HttpGet]
        [Route(template:"{id}")]
        public IActionResult Details(int id)
        {            
            return Ok(_cityRepository.Get(id));
        }

        //Crear
        [HttpPost]
        public IActionResult Post(City city)
        {
            _cityRepository.Post(city);
            return Ok(_cityRepository.GetAllEntities().ToList());
        }

        //Actualizar entidad
        [HttpPut]
        public IActionResult Put(City city)
        {
            return Ok(_cityRepository.Update(city));
        }

        [HttpDelete]
        [Route(template:"{id}")]
        public IActionResult Delete(int? id)
        {
            return Ok(_cityRepository.Delete(id));
        }
        
    }
}
