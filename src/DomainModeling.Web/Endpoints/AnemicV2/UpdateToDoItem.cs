using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace DomainModeling.Web.Endpoints.AnemicV2;

public class UpdateToDoItem : EndpointBaseAsync
				.WithRequest<UpdateToDoItemRequest>
				.WithActionResult<Project>
{
	/// <summary>
	/// Updates a ToDoItem
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[HttpPut("[namespace]/projects")]
	public override async Task<ActionResult<Project>> HandleAsync(UpdateToDoItemRequest request,
		CancellationToken cancellationToken = default)
	{
		var project = (await Data.Projects)
				.FirstOrDefault(p => p.Id == request.ProjectId);
		if (project == null) return NotFound();
		var item = project.ToDoItems
				.FirstOrDefault(i => i.Id == request.ToDoItemId);
		if (item == null) return NotFound();
		if (request.UpdatedIsDone)
		{
			NotificationService.NotifyToDoItemCompleted(item);
		}
		item.IsDone = request.UpdatedIsDone;
		item.Name = request.UpdatedName;

		return project;
	}
}
