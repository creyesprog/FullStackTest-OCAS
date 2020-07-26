using FullStack.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Models.ViewModels
{
    public class SubmissionListViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Activity { get; set; }
        public string Comments { get; set; }
    }
}
