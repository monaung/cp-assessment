using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Domain;
using Todo.Persistence;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITodoService _service;
        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var todoItemList =  await _service.GetAllTodoItems();;
            return Ok(todoItemList);
        }   



        [HttpGet("{id}")]
        public async Task<ActionResult> GetTodoItem(string id)
        {
            var todoItem= await _context.TodoItems.FindAsync(id);
            if(todoItem == null) return NotFound();

            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(string title, string note)
        {
            Console.Write(title);
            if(string.IsNullOrEmpty(title)) return BadRequest();

            var todoItem = await  _service.AddTodoItem(title,note);
            return todoItem;
        }

        [HttpPost]
        [Route("api/todo/hello")]
        public string Something() {

            return "I am fine";
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodoItem(string id, TodoItem item)
        {
            if(item.Id.ToString() != id || !TodoItemExist(id)) return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(string id)
        {
            var item = await _context.TodoItems.FindAsync(id); 

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExist(string id)
        {
            return _context.TodoItems.Any(i => i.Id.ToString() == id);
        }
    }
}