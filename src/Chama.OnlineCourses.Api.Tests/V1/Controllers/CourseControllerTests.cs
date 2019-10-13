using Chama.OnlineCourses.Api.Controllers;
using Chama.OnlineCourses.Api.Models.V1.Models;
using Chama.OnlineCourses.Api.V1.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.Tests.V1.Controllers
{
    public class CourseControllerTests
    {
        private Mock<IMediator> _mediator;
        private CourseController _controller;

        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
            _controller = new CourseController(_mediator.Object);
        }

        [Test]
        public async Task RegisterStudent_CommandIsValid_MediatorIsCalled()
        {
            //Arrange
            var command = new RegisterStudentCommand();

            //Act
            var result = await _controller.RegisterStudent(command);

            //Assert
            _mediator.Verify(x => x.Send(command, It.IsAny<CancellationToken>()), Times.Once);
            _mediator.VerifyNoOtherCalls();
        }

        [Test]
        public async Task RegisterStudent_CommandIsValid_CreatedIsReturned()
        {
            //Arrange
            var command = new RegisterStudentCommand();

            _mediator.Setup(x => x.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CourseDto());

            //Act
            var result = await _controller.RegisterStudent(command);

            //Assert
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public async Task RegisterStudent_CommandIsValid_CourseDtoIsReturned()
        {
            //Arrange
            var command = new RegisterStudentCommand();

            _mediator.Setup(x => x.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CourseDto());

            //Act
            var result = await _controller.RegisterStudent(command);
            var createdResult = result as CreatedResult;

            //Assert
            Assert.IsInstanceOf<CourseDto>(createdResult.Value);
        }
    }
}