namespace DomainModeling.Web.Endpoints.AnemicV2;
public class Project : BaseEntity
{
	public string Name { get; set; } = "";
	public List<ToDoItem> ToDoItems { get; set; } = new();
}
