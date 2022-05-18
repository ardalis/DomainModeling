namespace DomainModeling.Web.Endpoints.Encapsulated;
public class Project : BaseEntity
{
	public string Name { get; set; } = "";
	public List<ToDoItem> ToDoItems { get; set; } = new();
}
