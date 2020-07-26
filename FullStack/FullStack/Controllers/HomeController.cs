using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using FullStack.Infrastructure.Services.Interfaces;

namespace FullStack.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActivityService activityService;
        private readonly ISubmissionService submissionService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IActivityService activityService, ISubmissionService submissionService)
        {
            _logger = logger;
            this.activityService = activityService;
            this.submissionService = submissionService;
        }

        public async Task<IActionResult> Index()
        {
            List<SelectListItem> activities = null;

            // Call DB asynchronously to prepare any data before we throw it back to client. 
            // Just demonstrating an async implementation (much more useful with longer db queries/third party api calls)
            var taskActivity = activityService.GetActivitiesAsync();

            // Finish up tasks and prepare them for view model
            activities = await taskActivity.ContinueWith(x => x.Result.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ActivityId.ToString()
            }).ToList());

            // Prepare view model
            SubmissionViewModel viewModel = new SubmissionViewModel(activities);

            return View(viewModel);
        }

        public async Task<IActionResult> Submissions()
        {
            IList<SubmissionListViewModel> viewModel = await submissionService.GetSubmissionsAsync().ContinueWith(x =>
                x.Result.Select(submission => new SubmissionListViewModel()
                {
                    Email = submission.Email,
                    FirstName = submission.FirstName,
                    LastName = submission.LastName,
                    Comments = submission.Comments,
                    Activity = submission.Activity.Name
                }).ToList()
            );

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
