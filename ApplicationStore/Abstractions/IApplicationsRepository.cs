using ApplicationStore.Core.Models;

namespace ApplicationStore.DataAccess.Repositories
{
    public interface IApplicationsRepository
    {
        Task<Guid> Create(Application application);
        Task<Guid?> Delete(Guid id);
        Task<List<Application>> Get();
        Task<bool> FindAsync(Guid id);
        Task<List<ApplicationVeb>> GetSubmit(DateTime submit);
        Task<Application> GetOne(Guid id);
        Task<List<ApplicationVeb>> GetSubmitOlder(DateTime submit);
        Task<ApplicationVeb> Update(Guid id, string name, string activity, string description, string outline);
        Task<List<Activities>> GetActivities();
    }
}