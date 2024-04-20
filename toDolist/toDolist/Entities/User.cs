using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace toDolist.Entities
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public string Address { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;

        public ICollection<TodoItem> Talsks { get; set; } =new List<TodoItem>();
    }
}
