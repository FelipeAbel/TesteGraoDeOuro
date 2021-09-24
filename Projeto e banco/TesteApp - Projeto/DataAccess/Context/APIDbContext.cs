using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class APIDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder
            //.UseSqlServer(@"Server=FELIPEABEL-PC\SQLEXPRESS;Database=TesteApp;User Id=sa;Password=sm1234;");
            .UseSqlServer(@"Data Source=FELIPEABEL-PC;Initial Catalog=TesteApp;Integrated Security=True;");

        }
    }
}
