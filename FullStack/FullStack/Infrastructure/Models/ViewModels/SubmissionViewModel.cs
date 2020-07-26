using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FullStack.Infrastructure.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public SubmissionViewModel(List<SelectListItem> activities)
        {
            submissionActivities = activities;
            activities.Insert(0, new SelectListItem() { Text = "Select an activity", Value = "" });
        }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "Change your first name to fit 50 characters!")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Change your last name to fit 50 characters!")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Change your email to fit 50 characters!")]
        public string Email { get; set; }
        [MaxLength(50, ErrorMessage = "Change your message to fit 200 characters!")]
        public string Comments { get; set; }

        [Required]
        [Display(Name = "Activity")]
        public int? ActivityId { get; set; }

        public List<SelectListItem> submissionActivities { get; set; }
    }
}
