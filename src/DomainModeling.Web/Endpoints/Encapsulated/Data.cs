using System.Collections.ObjectModel;

namespace DomainModeling.Web.Endpoints.Encapsulated;

public class Data
{
  internal static ObservableCollection<Project> _projects = new();

  public static Task<List<Project>> Projects =>
      Task.FromResult<List<Project>>(_projects.ToList());

  static Data()
  {
    _projects.CollectionChanged += Projects_CollectionChanged;
  }

  private static void Projects_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
  {
    Console.WriteLine($"collection changed: {e}");
  }

  internal static void Seed(ILogger logger)
  {
    int currentProjectId = 1;
    int currentTaskId = 1;
    var project = new Project() { Id = currentProjectId++, Name = "First Project!" };
    project.ToDoItems.Add(new ToDoItem("Write Sample Code") { Id = currentTaskId++ });
    project.ToDoItems.Add(new ToDoItem("Write Blog Post") { Id = currentTaskId++ });
    project.ToDoItems.Add(new ToDoItem("Send Newsletter") { Id = currentTaskId++ });

    _projects.Add(project);

    logger.LogInformation($"Data seeded in Encapsulated namespace");

  }
}
