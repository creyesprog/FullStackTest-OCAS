using FullStack.Infrastructure.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Services.Interfaces
{
    public interface IActivityService
    {
        Task<IList<Activity>> GetActivitiesAsync();
        Task<Activity> GetActivityByIdAsync(int id);
    }
}