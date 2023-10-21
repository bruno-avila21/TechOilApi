using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Servicio
    {
        [Key] public int codServicio { get; set; }
        public string descr { get; set; }
        public Boolean estado { get; set; }
        public decimal valorHora { get; set; }
    }
}
