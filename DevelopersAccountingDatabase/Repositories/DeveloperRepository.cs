using DevelopersAccountingDatabase.Interfaces;
using DevelopersAccountingDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersAccountingDatabase.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly DevelopersAccountingDbContex _dbDeveloperContext;
        public DeveloperRepository(DevelopersAccountingDbContex dbContex)
        {
            _dbDeveloperContext = dbContex;
        }
        public async Task CreateAsync(Developer developer)
        {
            await _dbDeveloperContext.Developers.AddAsync(developer);
        }

        public async Task DeleteAsync(int id)
        {
            var developer = await _dbDeveloperContext.Developers.FindAsync(id);
            _dbDeveloperContext.Developers.Remove(developer);
        }

        public async Task<Developer> GetDeveloperAsync(int id)
        {
            return await _dbDeveloperContext.Developers.FindAsync(id);
            
        }

        public IEnumerable<Developer> GetDeveloperList()
        {
            return _dbDeveloperContext.Developers.Include(d => d.Projects);
        }

        public async Task SaveAsync()
        {
            await _dbDeveloperContext.SaveChangesAsync();
        }

        public void Update(Developer developer)
        {
            _dbDeveloperContext.Entry(developer).State = EntityState.Modified;
        }
    }
}
