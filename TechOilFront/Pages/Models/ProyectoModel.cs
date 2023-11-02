using System.ComponentModel.DataAnnotations;

namespace TechOilFront.Pages.Models
{
    public class ProyectoModel
    {
        [Key] public int codProyecto { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
    }
}
