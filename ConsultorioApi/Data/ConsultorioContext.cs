using Microsoft.EntityFrameworkCore;
using ConsultorioApi.Models;
namespace ConsultorioApi.Data
{
    public class ConsultorioContext: DbContext
    {
        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options) { }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }

    }
}
