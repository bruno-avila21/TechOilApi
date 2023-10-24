using TechOil.DataAcces;
using TechOil.Models;

namespace TechOil.Repository
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly TechOilDbContext _dbContext;

        public ServicioRepository(TechOilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddServicio(Servicio servicio)
        {
            _dbContext.Servicios.Add(servicio);
            _dbContext.SaveChanges();
        }

        public void DeleteServicio(int id)
        {
            var servicio = _dbContext.Servicios.FirstOrDefault(p => p.codServicio == id);
            if (servicio != null)
            {
                _dbContext.Servicios.Remove(servicio);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Servicio> GetAllServicos()
        {
            return _dbContext.Servicios.ToList();
        }

        public Servicio GetServicioById(int id)
        {
            return _dbContext.Servicios.FirstOrDefault(p => p.codServicio == id);
        }

        public void UpdateServicio(Servicio servicio)
        {
            _dbContext.Servicios.Update(servicio);
            _dbContext.SaveChanges();
        }
    }
}
