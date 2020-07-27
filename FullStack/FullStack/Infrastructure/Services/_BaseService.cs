using FullStack.Infrastructure.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Services
{
    public class _BaseService
    {
        protected IErrorModel ErrorModel { get; set; }

        public _BaseService(IErrorModel errorModel)
        {
            ErrorModel = errorModel;
        }

        protected void AddModelError(string error)
        {
            ErrorModel.Errors.Add(new Error { ErrorMessage = error });
        }
    }
}
