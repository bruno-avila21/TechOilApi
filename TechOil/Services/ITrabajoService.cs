using TechOil.Models;

namespace TechOil.Services
{
    public interface ITrabajoService
    {
        IEnumerable<Trabajo> GetAll();
        Trabajo GetById(int id);
        void Add(Trabajo trabajo);
        void Update(Trabajo trabajo);
        void Delete(int id);
    }
}
