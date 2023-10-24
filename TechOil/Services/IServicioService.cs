using TechOil.Models;

namespace TechOil.Services
{
    public interface IServicioService
    {
        IEnumerable<Servicio> GetAll();
        Servicio GetById(int id);
        void Add(Servicio servicio);
        void Update(Servicio servicio);
        void Delete(int id);
    }
}
