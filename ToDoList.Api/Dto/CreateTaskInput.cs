using AutoMapper;
using ToDoList.Core.Models;

namespace ToDoList.Dto;

[AutoMap(typeof(ToDoTask))]
public class CreateTaskInput
{
    public string Name { get; set; }
}