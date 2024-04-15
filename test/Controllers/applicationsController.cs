namespace ApplicationStore.Api.Controllers;
using ApplicationStore.Core.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationStore.Api.Contracts;
using ApplicationStore.Core.Abstractions;
using System.ComponentModel.DataAnnotations;
using ApplicationStore.Core.Validators;

[Route("[controller]")]
[ApiController]
public class applicationsController : ControllerBase
{
    private readonly IApplicationService _applicationsService;
    public applicationsController(IApplicationService applicationService)
    {
        _applicationsService = applicationService;
    }
    [HttpGet]
    public async Task<ActionResult<List<ApplicationsFullResponse>>> GetApplications()
    {
        var app = await _applicationsService.GetApplications();
        var response = app.Select(x => new ApplicationsFullResponse(x.id, x.activity, x.name, x.description, x.outline));
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<List<ApplicationsFullRequests>>> CreateApplication([FromBody] ApplicationsPostRequests requests)
    {
        var (application, error) = Application.Create(Guid.NewGuid(), requests.author,requests.activity,requests.name,requests.description,requests.outline,DateTime.MinValue);
        if(!string.IsNullOrEmpty(error) || requests.author == Guid.Empty) return BadRequest(error);
        var appId = await _applicationsService.GreateApplications(application);
        var response = new ApplicationsFullRequests(appId, requests.author,requests.activity, requests.name, requests.description, requests.outline);
        return Ok(response);
    }
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ApplicationVeb>> UpdateApplication(Guid id, [FromBody] ApplicationsPutResponse requests)
    {
        var error = ValidatorApp.ValidatorContractPut(id, requests.Activity, requests.Name, requests.Description, requests.Outline);
        if (!String.IsNullOrEmpty(error)) return BadRequest(error);
        var updatedApplication = await _applicationsService.UpdateApplications(id, requests.Activity, requests.Name, requests.Description, requests.Outline);
        if (updatedApplication == null) return BadRequest("Ошибка обновления записи."); 
        return Ok(updatedApplication);
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteApplications(Guid id)
    {
        var updatedApplication = await _applicationsService.DeleteApplications(id);
        if (updatedApplication == null) return BadRequest("Ошибка обновления записи.");
        return Ok();
    }
    [HttpPost("{id:guid}/submit")]
    public async Task<IActionResult> CreateOfficialApplication(Guid id)
    {
        var response = await _applicationsService.FindAsyncApplications(id);
        if (response) return Ok();
        else return NotFound();
    }
    [HttpGet("submittedAfter")]
    public async Task<ActionResult<List<Application>>> GetApplicationsSubmittedAfterDate([FromQuery] DateTime submit)
    {
        var applications = await _applicationsService.GetSubmittedApplications(submit);
        if (applications != null) return Ok(applications);
        else return NotFound();

    }
    [HttpGet("unsubmittedOlder")]
    public async Task<ActionResult<List<ApplicationVeb>>> GetUnsubmittedApplicationsOlder([FromQuery] DateTime submit)
    {
        var applications = await _applicationsService.GetSubmittedApplications(submit);
        if (applications != null) return Ok(applications);
        else return NotFound();
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Application>> GetOneApp(Guid id)
    {
        var application = await _applicationsService.GetOneApplications(id);
        if (application != null) return Ok(application);
        else return NotFound();
    }
}
