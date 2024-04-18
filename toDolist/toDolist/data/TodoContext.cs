using Microsoft.EntityFrameworkCore;
using toDolist.Entities;
namespace toDolist.data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions <TodoContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id); 

            modelBuilder.Entity<TodoItem>()
                .HasKey(t => t.Id_todo_item); 

            modelBuilder.Entity<User>()
                .HasMany(u => u.Talsks) // Navigation property on User (collection of TodoItems)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UserId); // Foreign key column on TodoItem
        }

    }
}
