using codnity_todo_homework.Data;
using codnity_todo_homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codnity_todo_homework.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(TodoDbContext context) : ControllerBase
{
    private readonly TodoDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        return Ok(await _context.TodoItems.ToListAsync());
    }

    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodosByDescription(string? description)
    {
        var todos = await _context.TodoItems.ToListAsync();

        if (!string.IsNullOrWhiteSpace(description))
        {
            todos = todos.Where(todo => todo.Description != null && todo.Description.Contains(description, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todo = await _context.TodoItems.FindAsync(id);

        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> PostTodoItem(Todo todo)
    {
        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(int id)
    {

        var todo = _context.TodoItems.Find(id);

        if (todo == null)
        {
            return BadRequest();
        }

        todo.IsDone = !todo.IsDone;

        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
