using TechOil.Models;
using TechOil.Repository;

namespace TechOil.Services
{
    public class TrabajoService
    {

        private readonly ITrabajoRepository<Trabajo> _trabajoRepository;

        public TrabajoService(ITrabajoRepository<Trabajo> trabajoRepository)
        {
            _trabajoRepository = trabajoRepository;
        }

        public Trabajo GetById(int trabajoId)
        {
            return _trabajoRepository.GetTrabajoById(trabajoId);
        }

        public IEnumerable<Trabajo> GetAll()
        {
           return  _trabajoRepository.GetAllTrabajos();
        }

        public void Add(Trabajo trabajo)
        {
            _trabajoRepository.AddTrabajo(trabajo);
        }

        public void Update(Trabajo trabajo)
        {
            _trabajoRepository.UpdateTrabajo(trabajo);
        }

        public void Delete(int trabajoId)
        {
            var trabajo = _trabajoRepository.GetTrabajoById(trabajoId);

            if(trabajo  != null)
            {
                _trabajoRepository.DeleteTrabajo(trabajoId);
            }
        }
    }
}
