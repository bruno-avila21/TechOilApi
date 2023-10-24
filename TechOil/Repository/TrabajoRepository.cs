using TechOil.DataAcces;
using TechOil.Models;

namespace TechOil.Repository
{
    public class TrabajoRepository : ITrabajoRepository
    {
        private readonly TechOilDbContext _dbContext;

        public TrabajoRepository(TechOilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTrabajo(Trabajo trabajo)
        {
            _dbContext.Trabajos.Add(trabajo);
            _dbContext.SaveChanges();
        }

        public void DeleteTrabajo(int id)
        {
            var trabajo = _dbContext.Trabajos.FirstOrDefault(p => p.codTrabajo == id);
            if (trabajo != null)
            {
                _dbContext.Trabajos.Remove(trabajo);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Trabajo> GetAllTrabajos()
        {
            return _dbContext.Trabajos.ToList();
        }

        public Trabajo GetTrabajoById(int id)
        {
            return _dbContext.Trabajos.FirstOrDefault(p => p.codTrabajo == id);
        }

        public void UpdateTrabajo(Trabajo trabajo)
        {
            _dbContext.Trabajos.Update(trabajo);
            _dbContext.SaveChanges();
        }
    }
}
