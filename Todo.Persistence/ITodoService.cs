using Todo.Domain;

namespace Todo.Persistence;

public interface ITodoService
{
    
    Task<List<TodoItem>> GetAllTodoItems();
    List<TodoItem> GetAllCompletedTodoItems();
    List<TodoItem> GetAllImportantTodoItems();
    TodoItem GetTodoItemById(Guid id);
    Task<TodoItem> AddTodoItem(string title, string note);
    TodoItem UpdateTodoItem(Guid id, TodoItem todoItem);
    bool DeleteTodoItem(Guid id);
}
