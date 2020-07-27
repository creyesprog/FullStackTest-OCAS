using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Models.DTOs
{
    public class ErrorModel : IErrorModel
    {
        public List<IError> Errors { get; set; }

        public ErrorModel()
        {
            Errors = new List<IError>();
        }
    }

    public class Error : IError
    {
        public string ErrorMessage { get; set; }
    }
}
