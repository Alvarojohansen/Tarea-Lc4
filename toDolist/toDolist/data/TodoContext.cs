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
    }
}
