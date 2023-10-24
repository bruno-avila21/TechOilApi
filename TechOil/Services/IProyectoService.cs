using TechOil.Models;

namespace TechOil.Services
{
    public interface IProyectoService
    {
        IEnumerable<Proyecto> GetAll();
        Proyecto GetById(int id);
        void Add(Proyecto proyecto);
        void Update(Proyecto proyecto);
        void Delete(int id);
    }
}
