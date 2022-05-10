using ToDoList.Core.Enums;
using TaskStatus = ToDoList.Core.Enums.TaskStatus;

namespace ToDoList.Dto;

public class GetAllTasksInput
{
    public TaskStatus Status { get; set; }
}