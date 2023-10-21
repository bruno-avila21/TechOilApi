﻿using TechOil.Models;

namespace TechOil.Repository
{
    public interface IUsuarioRepository<Usuario>
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(int id);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int id);
    }
}
