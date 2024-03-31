using ApplicationStore.Core.Models;

namespace ApplicationStore.DataAccess.Repositories
{
    public interface IApplicationsRepository
    {
        Task<Guid> Create(Application application);
        Task<Guid> Delete(Guid id);
        Task<List<Application>> Get();

        Task<bool> FindAsync(Guid id);
        Task<List<Guid>> GetSubmit(DateTime submit);

        Task<Application> GetOne(Guid id);
        Task<List<Guid>> GetSubmitOlder(DateTime submit);
        Task<Guid> Update(Guid id, string name, string activity, string description, string outline);
    }
}