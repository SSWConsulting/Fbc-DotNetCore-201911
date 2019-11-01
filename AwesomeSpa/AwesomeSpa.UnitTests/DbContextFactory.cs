using AwesomeSpa.Data;
using AwesomeSpa.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AwesomeSpa.UnitTests
{
    public static class DbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            Seed(context);

            return context;
        }

        private static void Seed(ApplicationDbContext context)
        {
            context.TodoItems.AddRange(
                new TodoItem { Id = 1, Title = "Do this thing." },
                new TodoItem { Id = 2, Title = "Do this thing too." },
                new TodoItem { Id = 3, Title = "Do yet another thing." },
                new TodoItem { Id = 4, Title = "Steal Brendan's lunch.", Done = true, Completed = new DateTime(2019, 10, 31) }
            );

            context.SaveChanges();
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
