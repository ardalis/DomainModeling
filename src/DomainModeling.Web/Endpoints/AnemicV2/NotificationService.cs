
namespace DomainModeling.Web.Endpoints.AnemicV2;

/// <summary>
/// Sends interested parties notifications
/// </summary>
public static class NotificationService
{
	public static void NotifyToDoItemCompleted(ToDoItem item)
	{
		Console.WriteLine($"Item {item.Name} is complete.");
	}
}
