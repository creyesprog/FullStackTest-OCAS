using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Models.DTO;
using FullStack.Infrastructure.Models.DTOs;
using FullStack.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FullStack.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ILogger<Submission> logger;
        private readonly ISubmissionService submissionService;

        public SubmissionController(ILogger<Submission> _logger, ISubmissionService submissionService)
        {
            logger = _logger;
            this.submissionService = submissionService;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody]SubmissionDTO bindingModel)
        {
            ResponseDTO dto = new ResponseDTO();

            try
            {
                if (ModelState.IsValid)
                {
                    // Massage data
                    bindingModel.Email = bindingModel.Email.Trim();
                    bindingModel.FirstName = bindingModel.FirstName.Trim();
                    bindingModel.LastName = bindingModel.LastName.Trim();
                    bindingModel.Comments = bindingModel.Comments.Trim();

                    // Call service to add submission 
                    await  submissionService.AddSubmissionAsync(bindingModel.Email, bindingModel.FirstName, bindingModel.LastName, bindingModel.Comments, bindingModel.ActivityId.Value);

                    // TODO: Should be throwing an object here with errors if any accumulated in service.
                    // Ideally should use model state. Need to utilize dependency injection and shared

                    return Ok(dto);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                logger.LogError(ex.StackTrace);
            }

            return BadRequest(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}