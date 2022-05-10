using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Core;
using ToDoList.Core.Models;
using ToDoList.Dto;

namespace ToDoList.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ToDoListContext _dbContext;
    private readonly IMapper _mapper;

    public TasksController(ToDoListContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    [HttpPost("Create")]
    public async Task Create(CreateTaskInput input)
    {
        int userId = 1;
        var task = _mapper.Map<ToDoTask>(input);
        task.UserId = userId;
        
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();
    }
}