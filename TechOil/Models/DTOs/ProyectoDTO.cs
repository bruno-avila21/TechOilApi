using System.ComponentModel.DataAnnotations;

namespace TechOil.Models.DTOs
{
    public class ProyectoDTO
    {
        [Key] public int codProyecto { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
    }
}
