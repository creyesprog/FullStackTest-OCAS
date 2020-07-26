using System;
using System.Collections.Generic;

namespace FullStack.Infrastructure.Database.Models
{
    public partial class Submission
    {
        public int SubmissionId { get; set; }
        public int ActivityId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comments { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
