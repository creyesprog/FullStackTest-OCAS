using FullStack.Infrastructure.Database;
using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Repositories
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly FullStackTestContext db;

        public SubmissionRepository(FullStackTestContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Submission>> GetSubmissionsAsync()
        {
            return await db.Submission.ToListAsync();
        }

        public async Task<EntityEntry<Submission>> InsertSubmissionAsync(Submission submission)
        {
            return await db.Submission.AddAsync(submission);
        }

        public async Task<bool> SaveChangesAsync()
        {
            bool success = false;
            try
            {
                success = await db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                // Add logger here
            }
            return success;
        }
    }
}
