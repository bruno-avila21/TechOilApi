using System.ComponentModel.DataAnnotations;

namespace TechOil.Models.DTOs
{
    public class TrabajoDTO
    {
        [Key] public int codTrabajo { get; set; }
        public int codProyecto { get; set; }
        public int codServicio { get; set; }
        public int cantHoras { get; set; }
    }
}
