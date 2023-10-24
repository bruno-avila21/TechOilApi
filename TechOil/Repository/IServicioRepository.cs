using TechOil.Models;

namespace TechOil.Repository
{
    public interface IServicioRepository
    {
        IEnumerable<Servicio> GetAllServicos();
        Servicio GetServicioById(int id);
        void AddServicio(Servicio servicio);
        void UpdateServicio(Servicio servicio);
        void DeleteServicio(int id);
    }
}
