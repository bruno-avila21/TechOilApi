using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

            private readonly IProyectoService _proyectoService;
            public readonly IMapper _mapper;

            public ProyectosController(IProyectoService proyectoService, IMapper mapper)
            {
                _proyectoService = proyectoService;
                _mapper = mapper;
            }

            // GET: api/proyectos
            [HttpGet] 
            public IActionResult GetProyectos()
            {
                var proyectos = _proyectoService.GetAll();

                var proyectosDTO = _mapper.Map<List<ProyectoDTO>>(proyectos);

                return Ok(proyectosDTO);
            }

            // GET api/proyectos/{id}
            [HttpGet("{id}")]
            [Authorize]
            public IActionResult Get(int id)
            {
                var proyecto = _proyectoService.GetById(id);
                if (proyecto == null)
                {
                    return NotFound();
                }
            var proyectoDTO = _mapper.Map<ProyectoDTO>(proyecto);

                return Ok(proyectoDTO);
            }

            // POST api/proyectos
            [HttpPost]
        //    [Authorize]
        public IActionResult Post(Proyecto proyecto)
            {
                _proyectoService.Add(proyecto);
                return CreatedAtAction(nameof(Get), new { id = proyecto.codProyecto }, proyecto);
            }

            // PUT api/proyectos/{id}
            [HttpPut("{id}")]
            [Authorize]
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
         //   [Authorize]
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
