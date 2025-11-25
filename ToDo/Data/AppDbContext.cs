using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=todosApp.db");
        }
    }
}
