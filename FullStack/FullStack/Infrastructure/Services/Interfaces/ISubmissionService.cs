using FullStack.Infrastructure.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Services.Interfaces
{
    public interface ISubmissionService
    {
        Task<bool> AddSubmissionAsync(string email, string firstName, string lastName, string comments, int activityId);
        Task<IEnumerable<Submission>> GetSubmissionsAsync();
    }
}