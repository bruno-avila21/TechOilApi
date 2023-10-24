using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Proyecto
    {
        [Key] public int codProyecto { get; set; } 
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int estado { get; set; }
    }
}
