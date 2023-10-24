using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Repository;
using TechOil.Services;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/usuarios
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var usuarios = _usuarioService.GetAll();
            return Ok(usuarios);
        }

        // GET api/usuarios/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST api/usuarios
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            _usuarioService.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.codUsuario }, usuario);
        }

        // PUT api/usuarios/{id}
        [HttpPut("{id}")]
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
