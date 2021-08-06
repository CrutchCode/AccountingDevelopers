using DevelopersAccountingDatabase.Interfaces;
using DevelopersAccountingDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersAccountingDatabase.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevelopersAccountingDbContex _dbProjectContext;
        public ProjectRepository(DevelopersAccountingDbContex dbContex)
        {
            _dbProjectContext = dbContex;
        }
        public async Task CreateAsync(Project project)
        {
            await _dbProjectContext.Projects.AddAsync(project);
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _dbProjectContext.Projects.FindAsync(id);
            _dbProjectContext.Projects.Remove(project);
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            return await _dbProjectContext.Projects.FindAsync(id);
        }

        public IEnumerable<Project> GetProjectList()
        {
            return _dbProjectContext.Projects.Include(p => p.Developers);
        }

        public async Task SaveAsync()
        {
            await _dbProjectContext.SaveChangesAsync();
        }

        public void Update(Project project)
        {
            _dbProjectContext.Entry(project).State = EntityState.Modified;
        }
    }
}
