using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Models
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }
}