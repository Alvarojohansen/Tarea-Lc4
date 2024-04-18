using System.ComponentModel.DataAnnotations;

namespace toDolist.Entities
{
    public class TodoItem
    {
        [Key]
        public int Id_todo_item { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int UserId { get; set; }

        public User Usuario { get; set; }
    }
}
