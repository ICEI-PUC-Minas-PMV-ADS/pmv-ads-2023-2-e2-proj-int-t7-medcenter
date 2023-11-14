
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;

namespace medcenter_backend.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
    }
}
