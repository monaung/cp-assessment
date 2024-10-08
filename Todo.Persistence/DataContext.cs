
using Todo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Todo.Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options) 
        {}
        public DataContext()
        {}
        
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
                Seeding default data
                ref - https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
            */

            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem{Id = Guid.NewGuid(), Title="Title 1", Note="", CreatedDate= DateTime.Now},
                new TodoItem{Id = Guid.NewGuid(), Title="Title 3", Note="", CreatedDate= DateTime.Now},
                new TodoItem{Id = Guid.NewGuid(), Title="Title 4", Note="", CreatedDate= DateTime.Now}
            );}
        }
    }
