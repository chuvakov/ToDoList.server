using AutoMapper;
using ToDoList.Core.Enums;
using ToDoList.Core.Models;

namespace ToDoList.Dto;

[AutoMap(typeof(ToDoTask), ReverseMap = true)]
public class TaskDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TaskStatus Status { get; set; }
}