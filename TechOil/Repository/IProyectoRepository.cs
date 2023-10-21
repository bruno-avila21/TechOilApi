using TechOil.Models;

namespace TechOil.Repository
{
    public interface IProyectoRepository<Proyecto>
    {
        IEnumerable<Proyecto> GetAllProyectos();
        Proyecto GetProyectoById(int id);
        void AddProyecto(Proyecto proyecto);
        void UpdateProyecto(Proyecto proyecto);
        void DeleteProyecto(int id);
    }
}
