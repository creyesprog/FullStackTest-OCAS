using FullStack.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Models.ViewModels
{
    public class SubmissionListViewModel
    {
        public string Email { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Activity { get; set; }
        public string Comments { get; set; }
    }
}
