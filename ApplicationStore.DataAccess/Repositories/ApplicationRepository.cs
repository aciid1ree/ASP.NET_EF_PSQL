using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationStore.DataAccess.Entities;
using ApplicationStore.Core.Models;
using static System.Net.Mime.MediaTypeNames;
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
            var ApplicationEntities = await _context.Applications3
                .AsNoTracking()
                .ToListAsync();
            var applicatons = ApplicationEntities
                .Select(b => Application.Create(b.Id, b.Author,b.Name, b.Activity, b.Description, b.Outline, b.Submitted).Application)
                .ToList();
            return applicatons;

        }

        public async Task<Guid> Create(Application application)
        {
            var applicationEntity = new ApplicationEntity
            {
                Id = application.Id,
                Author = application.Author,
                Name = application.Name,
                Activity = application.Activity,
                Description = application.Description,
                Outline = application.Outline,
                Submitted = application.Submitted
            };
            await _context.Applications3.AddAsync(applicationEntity);
            await _context.SaveChangesAsync();
            return applicationEntity.Id;
        }

        public async Task<Guid> Update(Guid id,string name, string activity, string description, string outline)
        {
            if (string.IsNullOrEmpty(activity) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(outline))
            {
                return Guid.Empty;
            }
            await _context.Applications3
               .Where(b => b.Id == id)
               .ExecuteUpdateAsync(s => s
                   .SetProperty(b => b.Name, b => name)
                   .SetProperty(b => b.Description, b => description)
                   .SetProperty(b => b.Activity, b => activity)
                   .SetProperty(b => b.Outline, b => outline));
            var authorIds = await _context.Applications3
                                 .Where(b => b.Id == id)
                                 .Select(b => b.Author)
                                 .FirstOrDefaultAsync();
            return authorIds;

        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Applications3
                .Where(b => b.Id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<bool> FindAsync(Guid id)
        {
            bool boolId = await _context.Applications3
            .Where(b => b.Id == id && b.Name != null && b.Outline != null)
            .AnyAsync();
            if (boolId)
            {
                var app = await _context.Applications3
                .FirstOrDefaultAsync(a => a.Id == id);
                app.Submitted = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return boolId;
        }

        public async Task<List<Guid>> GetSubmit(DateTime submit)
        {
            var ids = await _context.Applications3
                .Where(a => a.Submitted > submit)
                .Select(a => a.Id) 
                .ToListAsync();

            return ids;

        }

        public async Task<List<Guid>> GetSubmitOlder(DateTime submit)
        {
            var ids = await _context.Applications3
                .Where(a => a.Submitted > submit || a.Submitted == DateTime.MinValue)
                .Select(a => a.Id)
                .ToListAsync();

            return ids;

        }
        public async Task<Application> GetOne(Guid id)
        {
            var applicationEntity = await _context.Applications3
               .AsNoTracking()
               .FirstOrDefaultAsync(b => b.Id == id);
            return Application.Create(applicationEntity.Id, applicationEntity.Author, applicationEntity.Name, applicationEntity.Activity, applicationEntity.Description, applicationEntity.Outline, applicationEntity.Submitted).Application;
        }

    }
}
