using Geographic_Icons_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Geographic_Icons_API.Controllers
{
    [ApiController]
    [Route(template:"api/[controller]")]
    public class ContinentController : ControllerBase
    {
        //Inyección de Contexto para tener acceso a la DB.
        //Primero es necesario registrar nuestro contexto dentro de la Configuracion de servicios en la clase Startup.
        //Modificamos lo anterior para agregar DRepository.
        //Inyecto Repositorio de continente.

        private readonly IContinentRepository _continentRepository;

        public ContinentController(IContinentRepository continentRepository)
        {
            _continentRepository = continentRepository;
        }
        
        //Esto permite a NetCore generar lo necesario para usar este método como un EndPoint de la API
        //No especificamos una ruta precisa en cada método, pero si un nombre. Este Nombre coincide con el tipo de petición.
        //Cuando se hace la petición internamente llama al método de tipo Get con la ruta base del controlador.
        
        //Modificamos tipo de retorno a un IActionResult de status code tipo 200.
        //Nos devuelve el 1 uno en el mismo formato porque esto no poseee una estructura todavía, es solamente un valor numérico.
        //La diferencia es que ahora nosotros devolvemos un código http específico desde el código.
        
        
        [HttpGet]
        public IActionResult Get()
        {            
            return Ok(_continentRepository.GetAllEntities());   
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_continentRepository.Get(id));
        }

        //Crear
        [HttpPost]
        public IActionResult Post(Continent continent)
        {
            return Ok(_continentRepository.Post(continent));
        }

        //Modificar
        [HttpPut]
        public IActionResult Put(Continent continent)
        {
            return Ok(_continentRepository.Update(continent));
        }

        //Borrar
        [HttpDelete]
        [Route(template:"{id}")]
        public IActionResult Delete(int? id)
        {
            return Ok(_continentRepository.Delete(id));
        }
    }
}
