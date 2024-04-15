namespace ApplicationStore.Core.Abstractions;
using ApplicationStore.Core.Models;
public interface IApplicationService
{
    Task<Guid?> DeleteApplications(Guid id);
    Task<List<Application>> GetApplications();
    Task<Guid> GreateApplications(Application application);
    Task<bool> FindAsyncApplications(Guid id);
    Task<List<ApplicationVeb>> GetSubmittedApplications(DateTime submit);
    Task<Application> GetOneApplications(Guid id);
    Task<List<ApplicationVeb>> GetSubmitOlderApplications(DateTime submit);
    Task<ApplicationVeb> UpdateApplications(Guid id,string name, string activity, string description, string outline);
    Task<List<Activities>> GetActivitiesApplications();  
}