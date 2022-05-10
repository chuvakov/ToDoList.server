using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    [HttpPost("GetAll")]
    public async Task<IEnumerable<TaskDto>> GetAll(GetAllTasksInput input)
    {
        IQueryable<ToDoTask> query = _dbContext.Tasks
            .Where(x => x.Status == input.Status && x.UserId == 1);

        var tasks = await query.ToListAsync();
        return _mapper.Map<IEnumerable<TaskDto>>(tasks);
    }
}