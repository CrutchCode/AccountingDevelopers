using DevelopersAccountingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersAccountingDatabase.Interfaces
{
    public interface IDeveloperRepository
    {
        IEnumerable<Developer> GetDeveloperList();
        Task<Developer> GetDeveloperAsync(int id);
        Task CreateAsync(Developer item);
        void Update(Developer item);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
