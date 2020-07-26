using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Models.PartialModels
{
    public class ModalViewModel
    {
        public ModalViewModel()
        {
            PrimaryButtonId = "btn-modal-submit";
            PrimaryButtonText = "YES";
            SecondaryButtonText = "NO";
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string PrimaryButtonText { get; set; }
        public string SecondaryButtonText { get; set; }
        public string DataTarget { get; set; }
        public string PrimaryButtonId { get; set; }
    }
}
