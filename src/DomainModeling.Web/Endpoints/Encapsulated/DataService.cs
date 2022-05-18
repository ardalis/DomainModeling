using System.Collections.ObjectModel;
using MediatR;

namespace DomainModeling.Web.Endpoints.Encapsulated;

public class DataService
{
  internal static ObservableCollection<Project> _projects = new();

  public static Task<List<Project>> Projects =>
      Task.FromResult<List<Project>>(_projects.ToList());

  public IMediator Mediator { get; }

  public DataService(IMediator mediator)
  {
    Mediator = mediator;
  }

  public void SaveChanges()
  {
    foreach (var project in _projects)
    {
      foreach (var item in project.ToDoItems)
      {
        foreach (var domainEvent in item.Events)
        {
          Mediator.Publish(domainEvent);
        }
        item.ClearDomainEvents();
      }
    }

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
