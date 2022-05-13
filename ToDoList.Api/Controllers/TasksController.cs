using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public async Task<IActionResult> Create(CreateTaskInput input)
    {
        int userId = 1;
        var task = _mapper.Map<ToDoTask>(input);
        task.UserId = userId;
        
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("GetAll")]
    public async Task<IEnumerable<TaskDto>> GetAll(GetAllTasksInput input)
    {
        IQueryable<ToDoTask> query = _dbContext.Tasks
            .Where(x => x.Status == input.Status && x.UserId == 1);

        var tasks = await query.ToListAsync();
        return _mapper.Map<IEnumerable<TaskDto>>(tasks);
    }

    [HttpPost("Delete")]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        if (task == null)
        {
            return NotFound($"Задача с Id = {id} не найдена");
        }

        _dbContext.Tasks.Remove(task);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("Update")]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(UpdateTaskDto input)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == input.Id);
        if (task == null)
        {
            return NotFound($"Задача с Id = {input.Id} не найдена");
        }
        
        _mapper.Map(input, task);
        _dbContext.Tasks.Update(task);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}