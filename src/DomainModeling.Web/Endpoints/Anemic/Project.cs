namespace DomainModeling.Web.Endpoints.Anemic;
public class Project : BaseEntity
{
	public string Name { get; set; } = "";
	public List<ToDoItem> ToDoItems { get; set; } = new();
}
