using System.ComponentModel.DataAnnotations;

namespace TechOil.Models.DTOs
{
    public class UsuarioDTO
    {
        [Key] public int codUsuario { get; set; }
        public string nombre { get; set; }
        public int dni { get; set; }
        public int tipo { get; set; }
    }
}
