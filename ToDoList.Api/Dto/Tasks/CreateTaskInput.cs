using AutoMapper;
using ToDoList.Core.Models;

namespace ToDoList.Dto;

[AutoMap(typeof(ToDoTask), ReverseMap = true)]
public class CreateTaskInput
{
    public string Name { get; set; }
}