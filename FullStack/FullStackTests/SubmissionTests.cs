using Autofac.Extras.Moq;
using Castle.Core.Logging;
using Castle.DynamicProxy.Generators;
using FullStack.Controllers.APIs;
using FullStack.Infrastructure.Database.Models;
using FullStack.Infrastructure.Models.DTO;
using FullStack.Infrastructure.Models.DTOs;
using FullStack.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FullStackTests
{
    public class SubmissionTests
    {
        public IEnumerable<SubmissionDTO> GetTestSubmissions()
        {
            IEnumerable<SubmissionDTO> testSubmissions = new List<SubmissionDTO>()
            {
                new SubmissionDTO()
                {
                    FirstName = "Christian",
                    LastName = "Reyes",
                    Email = "creyes.prog@gmail.com",
                    Comments = "Comment test - christian",
                    ActivityId = 1
                },
                new SubmissionDTO()
                {
                    FirstName = "Tristan",
                    LastName = "Reyes",
                    Email = "treyes.prog@gmail.com",
                    Comments = "Comment test - tristan",
                    ActivityId = 1
                },
                new SubmissionDTO()
                {
                    FirstName = "Bob",
                    LastName = "Reyes",
                    Email = "breyes.prog@gmail.com",
                    Comments = "Comment test - bob",
                    ActivityId = 1
                },
                new SubmissionDTO()
                {
                    FirstName = "Fred",
                    LastName = "Reyes",
                    Email = "freyes.prog@gmail.com",
                    Comments = "Comment test - fred",
                    ActivityId = 1
                }
            };

            return testSubmissions;
        }

        [Fact]
        public async Task Post_OKResponse_GoodModel()
        {
            var mockSubmissionService = new Mock<ISubmissionService>();
            var mockLoggingService = new Mock<ILogger<SubmissionController>>();
            var mockErrorModel = new Mock<ErrorModel>();

            mockSubmissionService.Setup(serv => serv.AddSubmissionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(true)
                .Verifiable();

            var controller = new SubmissionController(mockLoggingService.Object, mockSubmissionService.Object, mockErrorModel.Object);

            var result = await controller.Post(GetTestSubmissions().First());

            var okRequest = Assert.IsType<OkObjectResult>(result); // Check if HTTP OK sent back
            var correctDto = Assert.IsType<ResponseDTO>(okRequest.Value); // Check if ResponseDTO sent
            Assert.Empty(correctDto.Errors); // Check if DTO has no errors listed.
        }

        [Fact]
        public async Task Post_BadResponse_ModelError()
        {
            var mockSubmissionService = new Mock<ISubmissionService>();
            var mockLoggingService = new Mock<ILogger<SubmissionController>>();
            var mockErrorModel = new Mock<ErrorModel>();

            mockSubmissionService.Setup(serv => serv.AddSubmissionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(true)
                .Verifiable();

            var controller = new SubmissionController(mockLoggingService.Object, mockSubmissionService.Object, mockErrorModel.Object);
            controller.ModelState.AddModelError("Error", "Error");

            var result = await controller.Post(GetTestSubmissions().First());

            var badRequest = Assert.IsType<BadRequestObjectResult>(result); // Check if HTTP Bad Request sent back
            var correctDto = Assert.IsType<ResponseDTO>(badRequest.Value); // Check if ResponseDTO sent
        }

        [Fact]
        public async Task Post_BadResponse_ErrorCountGreaterThanZero()
        {
            var mockSubmissionService = new Mock<ISubmissionService>();
            var mockLoggingService = new Mock<ILogger<SubmissionController>>();
            var mockErrorModel = new Mock<ErrorModel>();

            mockErrorModel.Object.Errors.Add(new Error() { ErrorMessage = "Random accumulated error from controller or service" });
            mockSubmissionService.Setup(serv => serv.AddSubmissionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(false)
                .Verifiable();

            var controller = new SubmissionController(mockLoggingService.Object, mockSubmissionService.Object, mockErrorModel.Object);

            var result = await controller.Post(GetTestSubmissions().First());

            var badRequest = Assert.IsType<BadRequestObjectResult>(result); // Check if HTTP Bad Request sent back
            var correctDto = Assert.IsType<ResponseDTO>(badRequest.Value); // Check if ResponseDTO sent
            Assert.NotEmpty(correctDto.Errors); // Check if DTO has errors listed.
        }
    }
}
