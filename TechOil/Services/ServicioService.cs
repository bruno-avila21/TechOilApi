using TechOil.Models;
using TechOil.Repository;

namespace TechOil.Services
{
    public class ServicioService
    {

        private readonly IServicioRepository<Servicio> _servicioRepository;

        public ServicioService(IServicioRepository<Servicio> servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }


        public Servicio GetById(int servicioId)
        {
           return _servicioRepository.GetServicioById(servicioId);
        }

        public IEnumerable<Servicio> GetAll()
        {
          return  _servicioRepository.GetAllServicos();
        }

        public void Update(Servicio servicio)
        {
            _servicioRepository.UpdateServicio(servicio);
        }

        public void Add(Servicio servicio)
        {
            _servicioRepository.AddServicio(servicio);
        }

        public void Delete(int servicioId)
        {
            var servicio = _servicioRepository.GetServicioById(servicioId);
            if(servicio != null)
            {
                _servicioRepository.DeleteServicio(servicioId);
            }
        }
    }
}
