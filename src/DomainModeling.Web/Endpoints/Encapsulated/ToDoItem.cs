using MediatR;

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
    RegisterDomainEvent(new ToDoItemCompletedEvent(this));
  }

  /// <summary>
  /// Handlers within domain entity classes can access private state of entities
  /// </summary>
  public class CompletedItemHandler : INotificationHandler<ToDoItemCompletedEvent>
  {
    public CompletedItemHandler() // TODO: Inject INotificationService here
    {
    }
    public Task Handle(ToDoItemCompletedEvent domainEvent, CancellationToken cancellationToken)
    {
      NotificationService.NotifyToDoItemCompleted(domainEvent.ToDoItem);

      return Task.CompletedTask;
    }
  }
}

// ToDoItem Events
public record ToDoItemCompletedEvent(ToDoItem ToDoItem) : DomainEventBase;
