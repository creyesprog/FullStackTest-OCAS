using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Repositories.Interfaces;
using FullStack.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public async Task<IList<Activity>> GetActivitiesAsync()
        {
            return await activityRepository.GetActivities();
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await activityRepository.GetActivityByIdAsync(id);
        }
    }
}
