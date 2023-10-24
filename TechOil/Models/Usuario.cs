using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Usuario
    {
        [Key] public int codUsuario { get; set; }
        public string nombre { get; set; }
        public int dni { get; set; }
        public int tipo { get; set; }
        public string contraseña { get; set; }
    
        public Usuario(string nombre, string contraseña)
        {
            this.nombre = nombre;
            this.contraseña = contraseña;
        }

    }
}
