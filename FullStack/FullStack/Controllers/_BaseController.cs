using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStack.Infrastructure.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.Controllers
{
    /// <summary>
    /// Used to add errors to solution
    /// </summary>
    public class _BaseController : Controller
    {
        protected IErrorModel ErrorModel;

        public _BaseController(IErrorModel errorModel) : base()
        {
            this.ErrorModel = errorModel;
        }

        protected void AddModelError(string error)
        {
            ErrorModel.Errors.Add(new Error() { ErrorMessage = error });
        }
    }
}