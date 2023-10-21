using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Models.DTOs;
using TechOil.Repository;
using TechOil.Services;

namespace TechOil.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProyectosController : ControllerBase
        {

            private readonly ProyectoService _proyectoService;

            public ProyectosController(ProyectoService proyectoService)
            {
                _proyectoService = proyectoService;
            }

            // GET: api/proyectos
            [HttpGet]
            public IActionResult GetProyectos()
            {
                var proyectos = _proyectoService.GetAll();

                var proyectosDTO = proyectos.Select(proyecto => new ProyectoDTO
                {
                codProyecto = proyecto.codProyecto,
                nombre = proyecto.nombre,
                direccion = proyecto.direccion
                 }).ToList();

                return Ok(proyectosDTO);
            }

            // GET api/proyectos/{id}
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var proyecto = _proyectoService.GetById(id);
                if (proyecto == null)
                {
                    return NotFound();
                }
                return Ok(proyecto);
            }

            // POST api/proyectos
            [HttpPost]
            public IActionResult Post(Proyecto proyecto)
            {
                _proyectoService.Add(proyecto);
                return CreatedAtAction(nameof(Get), new { id = proyecto.codProyecto }, proyecto);
            }

            // PUT api/proyectos/{id}
            [HttpPut("{id}")]
            public IActionResult Put(int id, Proyecto updatedProyecto)
            {
                var proyecto = _proyectoService.GetById(id);
                if (proyecto == null)
                {
                    return NotFound();
                }
                proyecto.nombre = updatedProyecto.nombre;
                proyecto.direccion = updatedProyecto.direccion;
                proyecto.estado = updatedProyecto.estado;
                _proyectoService.Update(proyecto);
                return NoContent();
            }

            // DELETE api/proyectos/{id}
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var proyecto = _proyectoService.GetById(id);
                if (proyecto == null)
                {
                    return NotFound();
                }
                _proyectoService.Delete(id);
                return NoContent();
            }
        }
    }
