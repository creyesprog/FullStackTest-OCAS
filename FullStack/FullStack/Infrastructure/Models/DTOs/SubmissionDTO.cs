using FullStack.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Models.DTO
{
    public class SubmissionDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Comments { get; set; }

        [Required]
        public int? ActivityId { get; set; }
    }
}
