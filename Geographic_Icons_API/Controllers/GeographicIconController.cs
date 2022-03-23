using Geographic_Icons_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Geographic_Icons_API.Controllers
{
    [Route("api/icons")]
    [ApiController]
    public class GeographicIconController : ControllerBase
    {
        //Inyección de dependencia.
        protected readonly IIconsRepository _iconsRepository;
        public GeographicIconController(IIconsRepository iconsRepository)
        {
            _iconsRepository = iconsRepository;
        }

        //Obtener entidades
        [HttpGet]
        public IActionResult Get(DateTime? date, string name = "", int cities = 0)
        {            
             
            if (!String.IsNullOrEmpty(name))
            {
                var selectMethod = _iconsRepository.GetAllEntities().Where(icon => icon.GeographicIconDenomination.ToUpper() == name.ToUpper())
                                        .Select(icon => new {
                                            IconPicture = icon.GeographicIconPicture,
                                            IconDenomination = icon.GeographicIconDenomination
                                        })
                                        .ToList();
                return Ok(selectMethod);
            }
            else if(date.HasValue)
            {
                var selectMethod = _iconsRepository.GetAllEntities().Where(icon => icon.CreationDate.Date == date.Value.Date && icon.CreationDate.Hour == date.Value.Hour
                && icon.CreationDate.Minute == date.Value.Minute && icon.CreationDate.Second == date.Value.Second)
                                        .Select(icon => new {
                                            IconPicture = icon.GeographicIconPicture,
                                            IconDenomination = icon.GeographicIconDenomination
                                        })
                                        .ToList();
                return Ok(selectMethod);
            }
            else if (cities != 0)
            {
                var selectMethod = _iconsRepository.GetAllEntities().Where(icon => icon.CityId == cities)
                                        .Select(icon => new {
                                            IconPicture = icon.GeographicIconPicture,
                                            IconDenomination = icon.GeographicIconDenomination
                                        }).ToList();
                return Ok(selectMethod);
            }
            else
            {
                var selectMethod = _iconsRepository.GetAllEntities().Select(icon => new {
                                IconPicture = icon.GeographicIconPicture,
                                IconDenomination = icon.GeographicIconDenomination
                            }).ToList();
                return Ok(selectMethod);
            }          
            
        }

        //Obtener detalles
        [HttpGet]
        [Route(template: "{id}")]
        public IActionResult Details(int id)
        {
            //Validacion
            if (_iconsRepository.GetAllEntities().FirstOrDefault(icon => icon.GeographicIconId == id) == null) { return BadRequest("El ícono no existe o el id no es válido"); }
            
            return Ok(_iconsRepository.Get(id));
        }

        //Crear
        [HttpPost]
        public IActionResult Post(GeographicIcon geographicIcon)
        {
            if (geographicIcon == null){ return BadRequest("No se puede crear un ícono vacío"); }
            //Objeto de prueba para la db, eliminé el objeto recibido de momento
            //DateTime fecha = DateTime.Now;
            //GeographicIcon geographicIcon = new GeographicIcon()
            //{
            //    GeographicIconDenomination = "Mariano",
            //    GeographicIconPicture = "URL2",
            //    CreationDate = fecha,
            //    Height = 2,
            //    History = "Muy Buena historia",
            //    CityId = 1

            //};
            _iconsRepository.Post(geographicIcon);
            return Ok(_iconsRepository.GetAllEntities().ToList());
        }

        //Actualizar entidad
        [HttpPut]
        public IActionResult Put(GeographicIcon geographicIcon)
        {
            //Validacion 
            if (_iconsRepository.GetAllEntities().FirstOrDefault(icon => icon.GeographicIconId == geographicIcon.GeographicIconId) == null){ return BadRequest("El ícono no existe"); }
            
            return Ok(_iconsRepository.Update(geographicIcon));
        }

        [HttpDelete]
        [Route(template: "{id}")]
        public IActionResult Delete(int? id)
        {
            //Validacion
            if (_iconsRepository.GetAllEntities().FirstOrDefault(icon => icon.GeographicIconId == id) == null){ return BadRequest("El ícono no existe o el id no es válido"); }
            
            return Ok(_iconsRepository.Delete(id));
        }
    }
}
