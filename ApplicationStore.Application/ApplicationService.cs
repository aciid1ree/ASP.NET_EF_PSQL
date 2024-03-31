using ApplicationStore.DataAccess.Repositories;
using ApplicationStore.Core.Models;

namespace ApplicationStore.App
{
    public class ApplicationService
    {
        public readonly IApplicationsRepository _applicationsRepository;
        public ApplicationService(IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }
        public async Task<List<Application>> GetApplications()
        {

        }
    }
}
