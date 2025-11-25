using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Data;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private AppDbContext _context = new AppDbContext();

        [HttpGet]
        public List<Todo> GetTodos()
        {
            return _context.Todos.ToList();
        }

        [HttpPost]
        public ActionResult addTodo([FromBody] Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return Created();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(Guid id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);

            if (todo is null)
            {
                return NotFound();
            }

            _context.Remove(todo);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public Todo UpdateTodo(Guid id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);

            if (todo is null)
            {
                return null;
            }

            todo.IsCompleted = !todo.IsCompleted;

            _context.SaveChanges();

            return todo;
        }

        [HttpGet("{id}")]
        public Todo SelectTodo(Guid id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);

            if(todo is null)
            {
                return null;
            }

            return todo;
        }
    }
}
