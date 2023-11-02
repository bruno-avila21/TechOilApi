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
    public class TrabajosController : ControllerBase
    {

        private readonly ITrabajoService _trabajoService;
        public readonly IMapper _mapper;

        public TrabajosController(ITrabajoService trabajoService, IMapper mapper)
        {
            _trabajoService = trabajoService;
            _mapper = mapper;
        }

        // GET: api/trabajos
        [HttpGet]
        public IActionResult Get()
        {
            var trabajos = _trabajoService.GetAll();

            var trabajosDTO = _mapper.Map<List<TrabajoDTO>>(trabajos);
            return Ok(trabajosDTO);
        }

        // GET api/trabajos/{id}
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var trabajo = _trabajoService.GetById(id);
            if (trabajo == null)
            {
                return NotFound();
            }

            var trabajoDTO = _mapper.Map<TrabajoDTO>(trabajo);
            return Ok(trabajoDTO);
        }

        // POST api/trabajos
        [HttpPost]
        //[Authorize]
        public IActionResult Post(Trabajo trabajo)
        {
            _trabajoService.Add(trabajo);
            return CreatedAtAction(nameof(Get), new { id = trabajo.codTrabajo }, trabajo);
        }

        // PUT api/trabajos/{id}
        [HttpPut("{id}")]
        [Authorize]
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
        //[Authorize]
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
