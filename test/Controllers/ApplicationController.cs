using ApplicationStore.App;
using ApplicationStore.App.Services;
using ApplicationStore.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using test.Contracts;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationsService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationsService = applicationService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ApplicationsResponse>>> GetApplications()
        {
            var app = await _applicationsService.GetApplications();
            var response = app.Select(x => new ApplicationsResponse(x.Id, x.Activity, x.Name, x.Description, x.Outline));
            return Ok(response);
        }

        [HttpPost("applications")]
        public async Task<ActionResult<List<ApplicationsRequests2>>> CreateApplication([FromBody] ApplicationsRequests requests)
        {
            var (application, error) = Application.Create(
                Guid.NewGuid(),
                requests.author,
                requests.activity,
                requests.name,
                requests.description,
                requests.outline,
                DateTime.MinValue);
            if(!string.IsNullOrEmpty(error) || requests.author == Guid.Empty)
            {
                return BadRequest(error);
            }
            var appId = await _applicationsService.GreateApplications(application);
            var response = new ApplicationsRequests2(appId, requests.author,requests.activity, requests.name, requests.description, requests.outline);
            return Ok(response);
        }

        [HttpPut("applications/{id:guid}")]
        public async Task<ActionResult<List<ApplicationsRequests2>>> UpdateApplication(Guid id, [FromBody] ApplicationsResponse2 requests)
        {
            var appId = await _applicationsService.UpdateApplications(id, requests.Activity, requests.Name, requests.Description, requests.Outline);
            if (appId == Guid.Empty) return NotFound("Заполните еще одно поле");
            var response = new ApplicationsRequests2(id, appId, requests.Activity, requests.Name, requests.Description, requests.Outline);
            return Ok(response);
        }

        [HttpDelete("applications/{id:guid}")]
        public async Task<IActionResult> DeleteApplications(Guid id)
        {
            await _applicationsService.DeleteApplications(id);
            return Ok();
        }

        [HttpPost("applications/{id:guid}/submit")]
        public async Task<IActionResult> CreateOfficialApplication(Guid id)
        {
            var response = await _applicationsService.FindAsyncApplications(id);
            if (response)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("applicationSubmittedAfter")]
        public async Task<ActionResult<List<Application>>> GetApplicationsSubmittedAfterDate([FromQuery] String submit)
        {
            DateTime submit1 = DateTime.ParseExact(submit, "yyyy-MM-dd HH:mm:ss.ff", null);
            DateTime submitUtc = submit1.ToUniversalTime();
            var applications = await _applicationsService.GetSubmittedApplications(submitUtc);
            if(applications != null)
            {
                var applicationsDetails = new List<Application>();
                foreach (var id in applications)
                {
                    var application = await _applicationsService.GetOneApplications(id);
                    applicationsDetails.Add(application);
                }
                return Ok(applicationsDetails);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("applicationsSubmittedOlder")]
        public async Task<ActionResult<List<Application>>> GetApplicationsSubmittedOlder([FromQuery] String submit)
        {
            DateTime submit1 = DateTime.ParseExact(submit, "yyyy-MM-dd HH:mm:ss.ff", null);
            DateTime submitUtc = submit1.ToUniversalTime();
            var applications = await _applicationsService.GetSubmitOlderApplications(submitUtc);
            if (applications != null)
            {
                var applicationsDetails = new List<Application>();
                foreach (var id in applications)
                {
                    var application = await _applicationsService.GetOneApplications(id);
                    applicationsDetails.Add(application);
                }
                return Ok(applicationsDetails);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("applications/{id:guid}")]
        public async Task<ActionResult<Application>> GetOneApp(Guid id)
        {
            var application = await _applicationsService.GetOneApplications(id);
            if (application != null) return Ok(application);
            else return NotFound();
        }

        [HttpGet("activities")]
        public async Task<ActionResult<List<ApplicationsRequests3>>> GetAcrivities()
        {
            var app = await _applicationsService.GetApplications();
            var response = app.Select(x => new ApplicationsRequests3(x.Activity, x.Description));
            return Ok(response);
        }
    }
}
