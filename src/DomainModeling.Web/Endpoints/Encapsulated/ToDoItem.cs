namespace DomainModeling.Web.Endpoints.Encapsulated;

/// <summary>
/// Represents a single task in a project
/// </summary>
public class ToDoItem : BaseEntity
{
  public ToDoItem(string name)
  {
    Name = name;
  }

  public string Name { get; set; } = "";
  public string Description { get; private set; } = "";
  public bool IsDone { get; private set; }

  public void MarkComplete()
  {
    if (IsDone) return;

    IsDone = true;

  }
}
