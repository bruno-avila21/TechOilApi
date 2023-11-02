using System.ComponentModel.DataAnnotations;

namespace TechOilFront.Pages.Models
{
    public class TrabajoModel
    {
        [Key] public int codTrabajo { get; set; }
        public int codProyecto { get; set; }
        public int codServicio { get; set; }
        public int cantHoras { get; set; }
    }
}
