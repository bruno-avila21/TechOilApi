using System.ComponentModel.DataAnnotations;

namespace TechOilFront.Pages.Models
{
    public class UsuarioModel
    {
        public int codUsuario { get; set; }
        public string nombre { get; set; }
        public int dni { get; set; }

        public string contraseña { get; set; }
    }
}
