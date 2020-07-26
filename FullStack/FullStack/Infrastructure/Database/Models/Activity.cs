using System;
using System.Collections.Generic;

namespace FullStack.Infrastructure.Database.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Submission = new HashSet<Submission>();
        }

        public int ActivityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Submission> Submission { get; set; }
    }
}
