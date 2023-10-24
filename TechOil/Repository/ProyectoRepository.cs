using TechOil.DataAcces;
using TechOil.Models;

namespace TechOil.Repository
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly TechOilDbContext _dbContext;

        public ProyectoRepository(TechOilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProyecto(Proyecto proyecto)
        {
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();
        }

        public void DeleteProyecto(int id)
        {
            var proyecto = _dbContext.Proyectos.FirstOrDefault(p => p.codProyecto == id);
            if (proyecto != null)
            {
                _dbContext.Proyectos.Remove(proyecto);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Proyecto> GetAllProyectos()
        {
            return _dbContext.Proyectos.ToList();
        }

        public Proyecto GetProyectoById(int id)
        {
            return _dbContext.Proyectos.FirstOrDefault(p => p.codProyecto == id);
        }

        public void UpdateProyecto(Proyecto proyecto)
        {
            _dbContext.Proyectos.Update(proyecto);
            _dbContext.SaveChanges();
        }
    }
}
