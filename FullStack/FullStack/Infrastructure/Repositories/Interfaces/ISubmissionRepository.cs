using FullStack.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Repositories.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<IEnumerable<Submission>> GetSubmissionsAsync();
        Task<EntityEntry<Submission>> InsertSubmissionAsync(Submission submission);
        Task<bool> SaveChangesAsync();
    }
}