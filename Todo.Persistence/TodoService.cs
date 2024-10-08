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
                Title = "Title 1",
                Note ="Note 1",
                CreatedDate = DateTime.Now
            },
            new TodoItem(){
                Title = "Title 2",
                Note ="Note 2",
                CreatedDate = DateTime.Now
            },
            new TodoItem(){
                Title = "Title 3",
                Note ="Note 3",
                CreatedDate = DateTime.Now
            },
        };
    }
    public async Task<TodoItem> AddTodoItem(TodoItem todoItem)
    {
         __dummyTodoItems.Add(new TodoItem(){
                Title = todoItem.Title,
                Note = todoItem.Note,
                CreatedDate = todoItem.CreatedDate
            });
            
            return await Task.FromResult(todoItem);
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
