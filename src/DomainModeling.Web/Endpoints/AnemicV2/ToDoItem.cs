namespace DomainModeling.Web.Endpoints.AnemicV2;

/// <summary>
/// Represents a single task in a project
/// </summary>
public class ToDoItem : BaseEntity
{
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
	public bool IsDone { get; set; }
}
