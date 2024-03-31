using ApplicationStore.Core.Models;


namespace ApplicationStore.App
{
    public interface IApplicationService
    {
        Task<Guid> DeleteApplications(Guid id);
        Task<List<Application>> GetApplications();
        Task<Guid> GreateApplications(Application application);

        Task<bool> FindAsyncApplications(Guid id);

        Task<List<Guid>> GetSubmittedApplications(DateTime submit);
        Task<Application> GetOneApplications(Guid id);
        Task<List<Guid>> GetSubmitOlderApplications(DateTime submit);
        Task<Guid> UpdateApplications(Guid id,string name, string activity, string description, string outline);
    }
}