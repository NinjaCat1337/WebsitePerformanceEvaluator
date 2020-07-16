using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositories
{
    public class SiteRepository : IRepository<Site>
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;

        public SiteRepository(IConfiguration configuration)
        {
            _dbContext = new ApplicationDbContext(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task CreateAsync(Site entity) => await _dbContext.AddAsync(entity);

        public void Update(Site entity) => _dbContext.Update(entity);

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Sites.FindAsync(id);

            if (entity == null)
                throw new Exception("Site not found or already deleted.");

            _dbContext.Sites.Remove(entity);
        }

        public async Task<IEnumerable<Site>> GetByAsync(Func<Site, bool> predicate)
        {
            var allSites = await _dbContext.Sites
                .Include(s => s.TestResults)
                .ThenInclude(tr => tr.SiteMapUrlResponseTimes)
                .ToListAsync();

            return allSites.Where(predicate);
        }

        public async Task<IEnumerable<Site>> GetAllAsync() => await _dbContext.Sites
            .Include(s => s.TestResults)
            .ThenInclude(tr => tr.SiteMapUrlResponseTimes)
            .ToListAsync();

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) _dbContext.Dispose();

            _disposed = true;
        }

        ~SiteRepository() => Dispose(false);
    }
}