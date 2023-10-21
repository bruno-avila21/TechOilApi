using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Repository;
using TechOil.Services;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajosController : ControllerBase
    {

        private readonly TrabajoService _trabajoService;

        public TrabajosController(TrabajoService trabajoService)
        {
            _trabajoService = trabajoService;
        }

        // GET: api/trabajos
        [HttpGet]
        public IActionResult Get()
        {
            var trabajos = _trabajoService.GetAll();
            return Ok(trabajos);
        }

        // GET api/trabajos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var trabajo = _trabajoService.GetById(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            return Ok(trabajo);
        }

        // POST api/trabajos
        [HttpPost]
        public IActionResult Post(Trabajo trabajo)
        {
            _trabajoService.Add(trabajo);
            return CreatedAtAction(nameof(Get), new { id = trabajo.codTrabajo }, trabajo);
        }

        // PUT api/trabajos/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, Trabajo updateTrabajo)
        {
            var trabajo = _trabajoService.GetById(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            trabajo.cantHoras = updateTrabajo.cantHoras;
            _trabajoService.Update(trabajo);
            return NoContent();
        }

        // DELETE api/trabajos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var trabajo = _trabajoService.GetById(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            _trabajoService.Delete(id);
            return NoContent();
        }
    }
}
