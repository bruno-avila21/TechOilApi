using Microsoft.EntityFrameworkCore;
using TechOil.Models;

namespace TechOil.DataAcces
{
    public class TechOilDbContext : DbContext
    {
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MILI\\SQLEXPRESS;Initial Catalog=TechOilApi;Integrated Security=True;Trust Server Certificate=true");
        }
    }
}
