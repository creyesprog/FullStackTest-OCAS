using Castle.Core.Logging;
using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Models.DTOs;
using FullStack.Infrastructure.Repositories.Interfaces;
using FullStack.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Services
{
    // TODO: Inject active ModelState into service for validation.
    public class SubmissionService : _BaseService, ISubmissionService
    {
        private readonly IActivityService activityService;
        private readonly ISubmissionRepository submissionRepository;
        private ILogger<SubmissionService> logger;

        public SubmissionService(ISubmissionRepository submissionRepository,
            IActivityService activityService,
            IErrorModel errorModel, ILogger<SubmissionService> logger) : base(errorModel)
        {
            this.submissionRepository = submissionRepository;
            this.activityService = activityService;
            this.logger = logger;
        }

        public async Task<IList<Submission>> GetSubmissionsAsync()
        {
            IList<Submission> submissions = new List<Submission>();

            try
            {
                submissions = await submissionRepository.GetSubmissionsAsync();
            }
            catch (DbException ex)
            {
                logger.LogError(ex.StackTrace);
                AddModelError("Error grabbing submissions from database.");
            }

            return submissions;
        }

        public async Task<bool> AddSubmissionAsync(string email, string firstName, string lastName, string comments, int activityId)
        {
            // Create submission
            bool success = false;

            try
            {
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

                success = await submissionRepository.SaveChangesAsync();

                if (!success)
                {
                    AddModelError("No submission saved.");
                }

            }
            catch (DbException ex)
            {
                logger.LogError(ex.StackTrace);
                AddModelError("Error sending to database.");
            }
            return success;
        }
    }
}