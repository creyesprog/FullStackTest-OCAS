using FullStack.Infrastructure.Database;
using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly FullStackTestContext db;

        public ActivityRepository(FullStackTestContext fullStackTestContext)
        {
            db = fullStackTestContext;
        }

        public async Task<IList<Activity>> GetActivities()
        {
            return await db.Activity.ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await db.Activity.Where(x => x.ActivityId == id).FirstOrDefaultAsync();
        }
    }
}
