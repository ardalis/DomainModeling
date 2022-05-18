namespace DomainModeling.Web.Endpoints.Encapsulated;
public class Project : EntityBase
{
	public string Name { get; set; } = "";
	public List<ToDoItem> ToDoItems { get; set; } = new();
}
