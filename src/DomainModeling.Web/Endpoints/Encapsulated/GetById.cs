﻿using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DomainModeling.Web.Endpoints.Encapsulated;

public class GetById : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<Project>
{

  private readonly DataService _dataService;

  public GetById(DataService dataService)
  {
    _dataService = dataService;
  }


  /// <summary>
  /// Gets a Project with its ToDoItems
  /// </summary>
  /// <param name="id"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  [HttpGet("[namespace]/projects/{id}")]
  [SwaggerOperation(Tags = new[] { "Anemic" })]
  public override async Task<ActionResult<Project>> HandleAsync(int id, CancellationToken cancellationToken = default)
  {
    var project = (await DataService.Projects).FirstOrDefault(p => p.Id == id);
    if (project == null) return NotFound();
    return Ok(project);
  }
}
