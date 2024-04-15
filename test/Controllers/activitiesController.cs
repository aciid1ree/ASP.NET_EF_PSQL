namespace ApplicationStore.Api.Controllers;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApplicationStore.Core.Abstractions;
[Route("api/[controller]")]
    [ApiController]
    public class activitiesController : ControllerBase
    {
        private readonly IApplicationService _activityService;
        public activitiesController(IApplicationService applicationService)
        {
            _activityService = applicationService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var activities = await _activityService.GetActivitiesApplications();
            return Ok(activities);
        }
    }

