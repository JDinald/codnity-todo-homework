using codnity_todo_homework.Models;
using Microsoft.EntityFrameworkCore;

namespace codnity_todo_homework.Data;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) :DbContext(options)
{
    public DbSet<Todo> TodoItems {get; set;}
}