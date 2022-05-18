using MediatR;

namespace DomainModeling.Web.Endpoints.Encapsulated;

public abstract record DomainEventBase : INotification
{ }
