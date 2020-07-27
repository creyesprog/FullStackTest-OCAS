using Castle.Core.Logging;
using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Repositories.Interfaces;
using FullStack.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace FullStack.Infrastructure.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;
        private readonly ILogger<ActivityService> logger;

        public ActivityService(IActivityRepository activityRepository, ILogger<ActivityService> logger)
        {
            this.activityRepository = activityRepository;
            this.logger = logger;
        }

        public async Task<IList<Activity>> GetActivitiesAsync()
        {
            IList<Activity> submissions = new List<Activity>();

            try
            {
                submissions = await activityRepository.GetActivities();
            }
            catch (DbException ex)
            {
                logger.LogError(ex.StackTrace);
            }

            return submissions;
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            Activity activity = null;

            try
            {
                activity = await activityRepository.GetActivityByIdAsync(id);
            }
            catch (DbException ex)
            {
                logger.LogError(ex.StackTrace);
            }

            return activity;
        }
    }
}
