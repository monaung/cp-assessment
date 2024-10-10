using System;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Controllers;
using Todo.Domain;
using Todo.Persistence;

namespace Todo.Tests;

public class TodoControllerTests
{
    ITodoService _service;
    TodoController controller;
    public TodoControllerTests()
    {
        _service = new TodoService();
        controller = new TodoController(_service);

    }
    
    [Fact]
    public async Task GetTodoItemsList_Success()
    {
        //Arrange
        int defaultItemsCount = 3;

        //Act
        var actionResult = await controller.GetTodoItems();

        //Assert
        var result = actionResult.Result as OkObjectResult;
        var resultTodoItemList = result.Value as IEnumerable<TodoItem>;
        Assert.Equal(defaultItemsCount, resultTodoItemList.Count());
    }

    [Fact]
    public async Task AddTodoList_Success()
    {
        //Arrange
        TodoItem todoItem =new TodoItem(){
            Title = "Test Title 1",
            Note ="Test Note 1",
            CreatedDate = DateTime.Now
        };

        //Act
        var result = await controller.CreateTodoItem(todoItem.Title, todoItem.Note);
        var actionResult = Assert.IsType<ActionResult<TodoItem>>(result);

        //Assert
        Assert.Equal(todoItem.Title, actionResult.Value.Title);
        Assert.Equal(todoItem.Note, actionResult.Value.Note);
    }
}
