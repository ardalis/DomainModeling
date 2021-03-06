using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DomainModeling.Web.Endpoints.Encapsulated;

public class Complete : EndpointBaseAsync
        .WithRequest<int>
        .WithActionResult<Project>
{
  private readonly DataService _dataService;

  public Complete(DataService dataService)
  {
    _dataService = dataService;
  }

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
    var project = (await DataService.Projects)
        .FirstOrDefault(p => p.Id == projectId);
    if (project == null) return NotFound();
    project.ToDoItems.ForEach(item => item.MarkComplete()); // Notifications should be sent here but aren't

    return project;
  }
}
