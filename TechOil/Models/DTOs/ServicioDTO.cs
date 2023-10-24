using System.ComponentModel.DataAnnotations;

namespace TechOil.Models.DTOs
{
    public class ServicioDTO
    {
        public string descr { get; set; }
        public Boolean estado { get; set; }
        public decimal valorHora { get; set; }
    }
}
