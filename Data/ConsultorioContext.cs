using Microsoft.EntityFrameworkCore;
using ConsultorioV2.Models;
namespace ConsultorioV2.Data
{
    public class ConsultorioContext: DbContext
    {
        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options) { }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<ContatoInfo> ContatoInfos { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }

    }
}
