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
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public readonly IMapper _mapper;


        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        // GET: api/usuarios
        [HttpGet]
       // [Authorize]
        public IActionResult Get()
        {
            var usuarios = _usuarioService.GetAll();

            var usuariosDTO = _mapper.Map<List<UsuarioDTO>>(usuarios);

            return Ok(usuariosDTO);
        }

        // GET api/usuarios/{id}
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            var usuarioDTO= _mapper.Map<UsuarioDTO>(usuario);

            return Ok(usuarioDTO);
        }

        // POST api/usuarios
        [HttpPost]
        //[Authorize]
        public IActionResult Post(Usuario usuario)
        {
            _usuarioService.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.codUsuario }, usuario);
        }

        // PUT api/usuarios/{id}
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, Usuario updateUsuario)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.nombre = updateUsuario.nombre;
            usuario.dni = updateUsuario.dni;
            usuario.tipo = updateUsuario.tipo;
            usuario.contraseña = updateUsuario.contraseña;

            _usuarioService.Update(usuario);
            return NoContent();
        }

        // DELETE api/usuarios/{id}
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _usuarioService.Delete(id);
            return NoContent();
        }
    }
}
