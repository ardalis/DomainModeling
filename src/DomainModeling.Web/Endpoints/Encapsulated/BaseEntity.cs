namespace DomainModeling.Web.Endpoints.Encapsulated;

public abstract class BaseEntity
{
  public int Id { get; set; }

  private List<DomainEvent> _events = new();
  private IEnumerable<DomainEvent> Events => _events.AsReadOnly();

  private void RegisterEvent(DomainEvent domainEvent) => _events.Add(domainEvent);
}
