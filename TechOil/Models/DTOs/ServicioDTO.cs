using System.ComponentModel.DataAnnotations;

namespace TechOil.Models.DTOs
{
    public class ServicioDTO
    {
        [Key] public int codServicio {  get; set; }
        public string descr { get; set; }
        public Boolean estado { get; set; }
        public decimal valorHora { get; set; }
    }
}
