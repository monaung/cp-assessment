using System;
using Todo.Domain;

namespace Todo.Persistence;

public class TodoService : ITodoService
{
     private readonly List<TodoItem> __dummyTodoItems;
    public TodoService()
    {
        __dummyTodoItems = new List<TodoItem>(){
            new TodoItem(){
                Title = "Pay utilities bill by Saturday",
                Note ="$100",
                CreatedDate = DateTime.Now
            },
            new TodoItem(){
                Title = "To buy movie tickets",
                Note ="2 tickets",
                CreatedDate = DateTime.Now
            },
            new TodoItem(){
                Title = "To setup meeting with John",
                Note ="Zoom",
                CreatedDate = DateTime.Now
            },
        };
    }
    public async Task<TodoItem> AddTodoItem(string title, string note)
    {
        var newTodo = new TodoItem(){
            Title = title,
            Note = note,
            CreatedDate = DateTime.Now
        };

         __dummyTodoItems.Add(newTodo);
            
        return await Task.FromResult(newTodo);
    }

    public bool DeleteTodoItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<TodoItem> GetAllCompletedTodoItems()
    {
        throw new NotImplementedException();
    }

    public List<TodoItem> GetAllImportantTodoItems()
    {
        throw new NotImplementedException();
    }

    public async Task<List<TodoItem>> GetAllTodoItems()
    {
           return await Task.FromResult(__dummyTodoItems);
    }

    public TodoItem GetTodoItemById(Guid id)
    {
        throw new NotImplementedException();
    }

    public TodoItem UpdateTodoItem(Guid id, TodoItem todoItem)
    {
        throw new NotImplementedException();
    }
}
