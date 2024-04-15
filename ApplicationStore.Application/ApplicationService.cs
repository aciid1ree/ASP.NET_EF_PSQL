using ApplicationStore.Core.Models;
using ApplicationStore.Core.Abstractions;
using ApplicationStore.DataAccess.Repositories;
namespace ApplicationStore.App.Services;
public class ApplicationService : IApplicationService
{
    public readonly IApplicationsRepository _applicationsRepository;

    public ApplicationService(IApplicationsRepository applicationsRepository)
    {
        _applicationsRepository = applicationsRepository;
    }
    public async Task<List<Application>> GetApplications()
    {
        return await _applicationsRepository.Get();
    }

    public async Task<Guid> GreateApplications(Application application)
    {
        return await _applicationsRepository.Create(application);
    }

    public async Task<ApplicationVeb> UpdateApplications(Guid id, string name, string title, string descripton, string outline)
    {
        return await _applicationsRepository.Update(id,name, title, descripton, outline);
    }

    public async Task<Guid?> DeleteApplications(Guid id)
    {
        return await _applicationsRepository.Delete(id);
    }

    public async Task<bool> FindAsyncApplications(Guid id)
    {
        return await _applicationsRepository.FindAsync(id);
    }

    public async Task<List<ApplicationVeb>> GetSubmittedApplications(DateTime submit)
    {
        return await _applicationsRepository.GetSubmit(submit);
    }
    public async Task<Application> GetOneApplications(Guid id)
    {
        return await _applicationsRepository.GetOne(id);
    }
    public async Task<List<ApplicationVeb>> GetSubmitOlderApplications(DateTime submit)
    {
        return await _applicationsRepository.GetSubmitOlder(submit);
    }
    public async Task<List<Activities>> GetActivitiesApplications()
    {
        return await _applicationsRepository.GetActivities();
    }
}
