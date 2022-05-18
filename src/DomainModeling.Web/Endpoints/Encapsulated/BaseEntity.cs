namespace DomainModeling.Web.Endpoints.Encapsulated;

public abstract class BaseEntity
{
  public int Id { get; set; }

  private List<DomainEventBase> _events = new();
  internal IEnumerable<DomainEventBase> Events => _events.AsReadOnly();

  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _events.Add(domainEvent);
  internal void ClearDomainEvents() => _events.Clear();
}
