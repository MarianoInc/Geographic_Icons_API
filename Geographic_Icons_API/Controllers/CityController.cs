using Geographic_Icons_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Geographic_Icons_API.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {//Inyección de dependencia.
        protected readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        //Obtener entidades
        [HttpGet]
        public IActionResult Get()
        {
            var selectMethod = _cityRepository.GetAllEntities().
                                          Select(city => new
                                          {
                                              CityPicture = city.CityPicture,
                                              CityName = city.CityName,
                                              Population = city.Population
                                          }).ToList();
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
