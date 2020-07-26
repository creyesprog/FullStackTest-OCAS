using FullStack.Infrastructure.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Repositories.Interfaces
{
    public interface IActivityRepository
    {
        Task<IList<Activity>> GetActivities();
        Task<Activity> GetActivityByIdAsync(int id);
    }
}