using AwesomeSpa.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeSpa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
