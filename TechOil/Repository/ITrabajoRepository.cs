using TechOil.Models;

namespace TechOil.Repository
{
    public interface ITrabajoRepository
    {
        IEnumerable<Trabajo> GetAllTrabajos();
        Trabajo GetTrabajoById(int id);
        void AddTrabajo(Trabajo trabajo);
        void UpdateTrabajo(Trabajo trabajo);
        void DeleteTrabajo(int id);
    }
}
