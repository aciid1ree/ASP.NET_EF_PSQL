using Microsoft.EntityFrameworkCore;
using ApplicationStore.DataAccess.Entities;
using ApplicationStore.Core.Models;
using Application = ApplicationStore.Core.Models.Application;

namespace ApplicationStore.DataAccess.Repositories
{
    public class ApplicationsRepository : IApplicationsRepository
    { 
        private readonly ApplicationStoreDbContext _context;
        public ApplicationsRepository(ApplicationStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Application>> Get()
        {
            var ApplicationEntities = await _context.Applications4
                .AsNoTracking()
                .ToListAsync();
            var applicatons = ApplicationEntities
                .Select(b => Application.Create(b.id, b.author,b.name, b.activity, b.description, b.outline, b.submitted).Application)
                .ToList();
            return applicatons;

        }
        public async Task<Guid> Create(Application application)
        {
            var applicationEntity = new ApplicationEntity
            {
                id = application.id,
                author = application.author,
                name = application.name,
                activity = application.activity,
                description = application.description,
                outline = application.outline,
                submitted = application.submitted
            };
            await _context.Applications4.AddAsync(applicationEntity);
            await _context.SaveChangesAsync();
            return applicationEntity.id;
        }
        public async Task<ApplicationVeb?> Update(Guid id,string name, string activity, string description, string outline)
        {
            bool boolId = await _context.Applications4
                .Where(b => b.id == id && b.submitted == DateTime.MinValue)
                .AnyAsync();
            if (!boolId) return null;
            await _context.Applications4
               .Where(b => b.id == id)
               .ExecuteUpdateAsync(s => s
                   .SetProperty(b => b.name, b => name)
                   .SetProperty(b => b.description, b => description)
                   .SetProperty(b => b.activity, b => activity)
                   .SetProperty(b => b.outline, b => outline));
            var applicationEntity = await _context.Applications4
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.id == id);
            var ans = Application.Create(applicationEntity.id, applicationEntity.author, applicationEntity.name, applicationEntity.activity, applicationEntity.description, applicationEntity.outline, applicationEntity.submitted).Application;
            var applicationWithoutSubmitted = new ApplicationVeb
            {
                Id = ans.id,
                Author = ans.author,
                Name = ans.name,
                Activity = ans.activity,
                Description = ans.description,
                Outline = ans.outline
            };
            return applicationWithoutSubmitted;
        }
        public async Task<Guid?> Delete(Guid id)
        {
            bool boolId = await _context.Applications4
               .Where(b => b.id == id && b.submitted == DateTime.MinValue)
               .AnyAsync();
            if (!boolId) return null;
            await _context.Applications4
                .Where(b => b.id == id).ExecuteDeleteAsync();
            return id;
        }
        public async Task<bool> FindAsync(Guid id)
        {
            bool boolId = await _context.Applications4
            .Where(b => b.id == id && b.name != null && b.outline != null)
            .AnyAsync();
            if (boolId)
            {
                var app = await _context.Applications4
                .FirstOrDefaultAsync(a => a.id == id);
                app.submitted = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return boolId;
        }
        public async Task<List<ApplicationVeb>> GetSubmit(DateTime submit)
        {
            DateTime submitUtc = submit.ToUniversalTime();
            var ids = await _context.Applications4
                .Where(a => a.submitted > submitUtc)
                .Select(a => a.id)
                .ToListAsync();
            var applicationsDetails = new List<ApplicationVeb>();
            foreach (var id in ids)
            {
                var ans = await _context.Applications4
                    .AsNoTracking()
                    .FirstOrDefaultAsync(b => b.id == id);
                var applicationWithoutSubmitted = new ApplicationVeb
                {
                    Id = ans.id,
                    Author = ans.author,
                    Name = ans.name,
                    Activity = ans.activity,
                    Description = ans.description,
                    Outline = ans.outline
                };
                applicationsDetails.Add(applicationWithoutSubmitted);
            }
            return applicationsDetails;
        }

        public async Task<List<ApplicationVeb>> GetSubmitOlder(DateTime submit)
        {
            var ids = await _context.Applications4
                .Where(a => a.submitted > submit || a.submitted == DateTime.MinValue)
                .Select(a => a.id)
                .ToListAsync();
            var applicationsDetails = new List<ApplicationVeb>();
            foreach (var id in ids)
            {
                var ans = await _context.Applications4
                    .AsNoTracking()
                    .FirstOrDefaultAsync(b => b.id == id);
                var applicationWithoutSubmitted = new ApplicationVeb
                {
                    Id = ans.id,
                    Author = ans.author,
                    Name = ans.name,
                    Activity = ans.activity,
                    Description = ans.description,
                    Outline = ans.outline
                };
                applicationsDetails.Add(applicationWithoutSubmitted);
            }
            return applicationsDetails;

        }
        public async Task<Application> GetOne(Guid id)
        {
            var applicationEntity = await _context.Applications4
               .AsNoTracking()
               .FirstOrDefaultAsync(b => b.id == id);
            return Application.Create(applicationEntity.id, applicationEntity.author, applicationEntity.name, applicationEntity.activity, applicationEntity.description, applicationEntity.outline, applicationEntity.submitted).Application;
        }

        public async Task<List<Activities>> GetActivities()
        {
            var activities = new List<Activities>
            {
                new Activities { baseactivity = "Report", description = "Доклад, 35-45 минут" },
                new Activities { baseactivity = "Masterclass", description = "Мастеркласс, 1-2 часа" },
                new Activities { baseactivity = "Discussion", description = "Дискуссия / круглый стол, 40-50 минут" }
            };
            return activities;
        }
    }
}
