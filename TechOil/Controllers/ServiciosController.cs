using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Repository;
using TechOil.Services;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {

        private readonly IServicioService _servicioService;

        public ServiciosController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        // GET: api/servicios
        [HttpGet]
        public IActionResult Get()
        {
            var servicios = _servicioService.GetAll();
            return Ok(servicios);
        }

        // GET api/servicios/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var servicio = _servicioService.GetById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return Ok(servicio);
        }

        // POST api/servicios
        [HttpPost]
        public IActionResult Post(Servicio servicio)
        {
            _servicioService.Add(servicio);
            return CreatedAtAction(nameof(Get), new { id = servicio.codServicio }, servicio);
        }

        // PUT api/servicios/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, Servicio updateServicio)
        {
            var servicio = _servicioService.GetById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            servicio.descr = updateServicio.descr;
            servicio.estado = servicio.estado;
            servicio.valorHora = servicio.valorHora;

            return NoContent();
        }

        // DELETE api/servicios/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var servicios = _servicioService.GetById(id);
            if (servicios == null)
            {
                return NotFound();
            }
            _servicioService.Delete(id);
            return NoContent();
        }
    }
}
