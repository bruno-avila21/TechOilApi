using TechOil.DataAcces;
using TechOil.Models;

namespace TechOil.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TechOilDbContext _dbContext;

        public UsuarioRepository(TechOilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUsuario(Usuario usuario)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            string hashedPassword= BCrypt.Net.BCrypt.HashPassword(usuario.contraseña, salt);

            usuario.contraseña = hashedPassword;

            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
        }

        public void DeleteUsuario(int id)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(p => p.codUsuario == id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _dbContext.Usuarios.ToList();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _dbContext.Usuarios.FirstOrDefault(p => p.codUsuario == id);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            _dbContext.SaveChanges();
        }
    }
}
