namespace toDolist.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string Address { get; set; } = string.Empty;
        public required string Name { get; set; } 
        public string Email { get; set; } = string.Empty;
    }
}
