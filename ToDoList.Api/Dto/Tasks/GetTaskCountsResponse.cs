namespace ToDoList.Dto;

public class GetTaskCountsResponse
{
    public int SuccessCount { get; set; }
    public int ActiveCount { get; set; }
    public int TotalCount { get; set; }
}