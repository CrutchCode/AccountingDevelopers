using DevelopersAccountingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersAccountingDatabase.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjectList();
        Task<Project> GetProjectAsync(int id);
        Task CreateAsync(Project item);
        void Update(Project item);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
