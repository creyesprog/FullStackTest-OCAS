using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Repositories.Interfaces;
using FullStack.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Services
{
    // TODO: Inject active ModelState into service for validation.
    public class SubmissionService : ISubmissionService
    {
        private readonly IActivityService activityService;
        private readonly ISubmissionRepository submissionRepository;

        public SubmissionService(ISubmissionRepository submissionRepository, IActivityService activityService)
        {
            this.submissionRepository = submissionRepository;
            this.activityService = activityService;
        }

        public async Task<IEnumerable<Submission>> GetSubmissionsAsync()
        {
            return await submissionRepository.GetSubmissionsAsync();
        }

        public async Task<bool> AddSubmissionAsync(string email, string firstName, string lastName, string comments, int activityId)
        {
            // Create submission
            Submission newSubmission = new Submission()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Comments = comments,
                TimeStamp = DateTime.Now.ToUniversalTime(),
                Activity = await activityService.GetActivityByIdAsync(activityId) // Link activity to submission
            };

            await submissionRepository.InsertSubmissionAsync(newSubmission);
            return await submissionRepository.SaveChangesAsync();
        }
    }
}