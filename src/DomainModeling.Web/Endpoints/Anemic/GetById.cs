using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DomainModeling.Web.Endpoints.Anemic;

public class GetById : EndpointBaseAsync
		.WithRequest<int>
		.WithActionResult<Project>
// https://ardalis.com/your-api-and-view-models-should-not-reference-domain-models/
{
	/// <summary>
	/// Gets a Project with its ToDoItems
	/// </summary>
	/// <param name="id">A Project Id</param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[HttpGet("[namespace]/projects/{id}")]
	[SwaggerOperation(Tags = new[] { "Anemic" })]
	public override async Task<ActionResult<Project>> HandleAsync(int id,
		CancellationToken cancellationToken = default)
	{
		var project = (await Data.Projects).FirstOrDefault(p => p.Id == id);
		if (project == null) return NotFound();
		return Ok(project);
	}
}
