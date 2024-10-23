using Microsoft.EntityFrameworkCore;

namespace Aluno_CRUD.Data
{
    public class DataContext : DbContext
    {
        // Construtor que aceita DbContextOptions<DataContext>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // DbSet para a entidade Aluno
        public DbSet<Aluno> Alunos { get; set; }
    }
}
