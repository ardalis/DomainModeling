namespace DomainModeling.Web.Endpoints.AnemicV2;

public class Data
{
  internal static List<Project> _projects = new();

  public static Task<List<Project>> Projects =>
      Task.FromResult<List<Project>>(_projects);

  internal static void Seed(ILogger logger)
  {
    int currentProjectId = 1;
    int currentTaskId = 1;
    var project = new Project() { Id = currentProjectId++, Name = "First Project!" };
    project.ToDoItems.Add(new ToDoItem() { Id = currentTaskId++, Name = "Write Sample Code" });
    project.ToDoItems.Add(new ToDoItem() { Id = currentTaskId++, Name = "Write Blog Post" });
    project.ToDoItems.Add(new ToDoItem() { Id = currentTaskId++, Name = "Send Newsletter" });

    _projects.Add(project);

    logger.LogInformation($"Data seeded in AnemicV2 namespace");

  }
}
