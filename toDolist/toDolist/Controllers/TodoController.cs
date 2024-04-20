using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using toDolist.data;
using toDolist.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace toDolist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly TodoContext _context;
        public TodoController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetAllTodoItem()
        {
            var allTodoItem = await _context.TodoItems.ToListAsync();
            return Ok(allTodoItem);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItemById(int id)
        {
            var dbTodoItem = await _context.TodoItems.FindAsync(id);

            if (dbTodoItem is null)
                return NotFound("todo item not found");
            return Ok(dbTodoItem);
        }

        [HttpPost]
        public async Task<ActionResult<List<TodoItem>>> AddTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return Ok(todoItem);
        }

        [HttpPut]
        public async Task<ActionResult<List<TodoItem>>> UpdateTodoItem(TodoItem todoItem)
        {
            var dbItem = await _context.TodoItems.FindAsync(todoItem.Id_todo_item);

            if (dbItem is null)
                return NotFound("item not found");

            dbItem.Title = todoItem.Title;
            dbItem.Description = todoItem.Description;
            dbItem.Usuario = todoItem.Usuario;

            await _context.SaveChangesAsync();
            return Ok(dbItem);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<TodoItem>>> DeleteItem(int id)
        {
            var dbItem = await _context.TodoItems.FindAsync(id);
            if (dbItem is null)
                return NotFound("item not found");

            _context.TodoItems.Remove(dbItem);
            await _context.SaveChangesAsync();
            return Ok(dbItem);
        }
    }
}
