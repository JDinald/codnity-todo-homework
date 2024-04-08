namespace codnity_todo_homework.Models;

public class Todo
{
    public int Id {get; set;}
    public string? Description {get; set;}
    public bool IsDone {get; set;} = false;
}
