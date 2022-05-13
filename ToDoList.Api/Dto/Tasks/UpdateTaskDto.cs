using AutoMapper;
using ToDoList.Core.Enums;
using ToDoList.Core.Models;

namespace ToDoList.Dto;

[AutoMap(typeof(ToDoTask), ReverseMap = true)]
public class UpdateTaskDto
{
    public int Id { get; set; }
    public TaskStatus Status { get; set; }
}