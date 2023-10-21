using TechOil.Models;
using TechOil.Repository;

namespace TechOil.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository<Usuario> _usuarioRepository;

        public UsuarioService(IUsuarioRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> GetAll()
        {
           return  _usuarioRepository.GetAllUsuarios();
        }

        public Usuario GetById(int usuarioId)
        {
            return _usuarioRepository.GetUsuarioById(usuarioId);
        }

        public void Add(Usuario usuario)
        {
            _usuarioRepository.AddUsuario(usuario);
        }

        public void Update(Usuario usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
        }

        public void Delete(int usuarioId)
        {
            var usuario = _usuarioRepository.GetUsuarioById(usuarioId);

            if(usuario  != null)
            {
                _usuarioRepository.DeleteUsuario(usuarioId);
            }
        }
    }
}
