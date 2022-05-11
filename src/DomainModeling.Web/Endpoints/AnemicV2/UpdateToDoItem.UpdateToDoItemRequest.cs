namespace DomainModeling.Web.Endpoints.AnemicV2;

public class UpdateToDoItemRequest
{
    public int ProjectId { get; set; }
    public int ToDoItemId { get; set; }
    public string UpdatedName { get; set; } = "";
    public bool UpdatedIsDone { get; set; }
}

