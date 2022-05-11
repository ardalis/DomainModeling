using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DomainModeling.Web.Endpoints.Anemic;

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
	public override async Task<ActionResult<Project>> HandleAsync(UpdateToDoItemRequest request, CancellationToken cancellationToken = default)
	{
		var project = (await Data.Projects)
				.FirstOrDefault(p => p.Id == request.ProjectId);
		if (project == null) return NotFound();
		var item = project.ToDoItems
				.FirstOrDefault(i => i.Id == request.ToDoItemId);
		if (item == null) return NotFound();
		item.IsDone = request.UpdatedIsDone;
		item.Name = request.UpdatedName;

		return project;
	}
}

