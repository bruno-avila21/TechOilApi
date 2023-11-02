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
    public class ServiciosController : ControllerBase
    {

        private readonly IServicioService _servicioService;
        public readonly IMapper _mapper;

        public ServiciosController(IServicioService servicioService, IMapper mapper)
        {
            _servicioService = servicioService;
            _mapper = mapper;
        }

        // GET: api/servicios
        [HttpGet]
        
        public IActionResult Get()
        {
            var servicios = _servicioService.GetAll();

            var serviciosDTO = _mapper.Map<List<ServicioDTO>>(servicios);
            return Ok(serviciosDTO);
        }

        // GET api/servicios/{id}
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var servicio = _servicioService.GetById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            var servicioDTO = _mapper.Map<ServicioDTO>(servicio);
            return Ok(servicioDTO);
        }

        // POST api/servicios
        [HttpPost]
        //[Authorize]
        public IActionResult Post(Servicio servicio)
        {
            _servicioService.Add(servicio);
            return CreatedAtAction(nameof(Get), new { id = servicio.codServicio }, servicio);
        }

        // PUT api/servicios/{id}
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, Servicio updateServicio)
        {
            var servicio = _servicioService.GetById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            servicio.descr = updateServicio.descr;
            servicio.estado = updateServicio.estado;
            servicio.valorHora = updateServicio.valorHora;
            _servicioService.Update(servicio);

            return NoContent();
        }

        // DELETE api/servicios/{id}
        [HttpDelete("{id}")]
       // [Authorize]
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
