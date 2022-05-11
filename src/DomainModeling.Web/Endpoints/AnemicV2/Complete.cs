using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DomainModeling.Web.Endpoints.AnemicV2;

public class Complete : EndpointBaseAsync
				.WithRequest<int>
				.WithActionResult<Project>
{
	/// <summary>
	/// Completes a project and all of its todo items
	/// </summary>
	/// <param name="projectId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[HttpPatch("[namespace]/projects/{projectId}")]
	[SwaggerOperation(Description = "Complete a Project", Summary = "Complete a Project", Tags = new[] { "Anemic" })]
	public override async Task<ActionResult<Project>> HandleAsync(int projectId,
	CancellationToken cancellationToken = default)
	{
		var project = (await Data.Projects)
				.FirstOrDefault(p => p.Id == projectId);
		if (project == null) return NotFound();
		project.ToDoItems.ForEach(item => item.IsDone = true); // Notifications should be sent here but aren't

		return project;
	}
}
