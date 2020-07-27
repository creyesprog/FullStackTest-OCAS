using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Models.DTO;
using FullStack.Infrastructure.Models.DTOs;
using FullStack.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace FullStack.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : _BaseController
    {
        private readonly ILogger<SubmissionController> logger;
        private readonly ISubmissionService submissionService;

        public SubmissionController(ILogger<SubmissionController> _logger,
            ISubmissionService submissionService,
            IErrorModel errorModel) : base(errorModel)
        {
            logger = _logger;
            this.submissionService = submissionService;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody]SubmissionDTO bindingModel)
        {
            ResponseDTO dto = new ResponseDTO(ErrorModel);

            if (ModelState.IsValid)
            {
                // Massage data
                bindingModel.Email = bindingModel.Email.Trim();
                bindingModel.FirstName = bindingModel.FirstName.Trim();
                bindingModel.LastName = bindingModel.LastName.Trim();
                bindingModel.Comments = bindingModel.Comments.Trim();

                // Call service to add submission 
                await submissionService.AddSubmissionAsync(bindingModel.Email, bindingModel.FirstName, bindingModel.LastName, bindingModel.Comments, bindingModel.ActivityId.Value);

                // Check if error model caught anything before sending ok response.
                if (ErrorModel.Errors.Count == 0)
                {
                    return Ok(dto);
                }
            }

            // TODO: Add field to ErrorModel to determine if 500 error should show
            return BadRequest(dto);
        }
    }
}