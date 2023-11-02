using System.ComponentModel.DataAnnotations;

namespace TechOilFront.Pages.Models
{
    public class ServicioModel
    {
        [Key] public int codServicio { get; set; }
        public string descr { get; set; }
        public decimal valorHora { get; set; }
    }
}
