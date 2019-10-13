using AutoMapper;
using Chama.OnlineCourses.Api.Models.V1.Models;
using Chama.OnlineCourses.Api.V1.Commands;
using Chama.OnlineCourses.Api.V1.Exceptions;
using Chama.OnlineCourses.Domain.AggregateModels.Course;
using Chama.OnlineCourses.Infrastructure.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.Tests.V1.Commands
{
    [TestFixture]
    public class RegisterStudentCommandHandlerTests
    {
        private Mock<ICourseRepository> _repository;
        private Mock<IMapper> _mapper;
        private RegisterStudentCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<ICourseRepository>();
            _mapper = new Mock<IMapper>();
            _handler = new RegisterStudentCommandHandler(_repository.Object, _mapper.Object);
        }

        [Test]
        public async Task Handle_CourseExists_RepositoryIsCalled()
        {
            //Arrange
            var courseId = Guid.NewGuid();
            var command = new RegisterStudentCommand { CourseId = courseId };
            var course = new Course
            {
                Id = courseId,
                Capacity = 10,
            };

            _repository.Setup(x => x.FindById(It.IsAny<Guid>())).ReturnsAsync(course);

            //Act
            await _handler.Handle(command, CancellationToken.None);

            //Assert
            _repository.Verify(x => x.FindById(command.CourseId), Times.Once);
            _repository.Verify(x => x.Upsert(course), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Handle_CourseExists_MapperIsCalled()
        {
            //Arrange
            var courseId = Guid.NewGuid();
            var studentDto = new StudentDto();
            var command = new RegisterStudentCommand { CourseId = courseId, Student = studentDto };
            var course = new Course
            {
                Id = courseId,
                Capacity = 10,
            };

            _repository.Setup(x => x.FindById(It.IsAny<Guid>())).ReturnsAsync(course);
            _mapper.Setup(x => x.Map<Student>(studentDto)).Returns(new Student());
            _mapper.Setup(x => x.Map<CourseDto>(course)).Returns(new CourseDto());

            //Act
            await _handler.Handle(command, CancellationToken.None);

            //Assert
            _mapper.Verify(x => x.Map<Student>(studentDto), Times.Once);
            _mapper.Verify(x => x.Map<CourseDto>(course), Times.Once);
            _mapper.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Handle_CourseDoesNotExists_CourseNotFoundExceptionIsThrown()
        {
            //Arrange
            var command = new RegisterStudentCommand();

            //Act & Assert
            Assert.ThrowsAsync<CourseNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task Handle_CourseExists_StudentIsAdded()
        {
            //Arrange
            var courseId = Guid.NewGuid();
            var studentDto = new StudentDto();
            var command = new RegisterStudentCommand { CourseId = courseId, Student = studentDto };
            var course = new Course
            {
                Id = courseId,
                Capacity = 10,
            };
            var student = new Student { FirstName = "Jonathan" };

            _repository.Setup(x => x.FindById(It.IsAny<Guid>())).ReturnsAsync(course);
            _mapper.Setup(x => x.Map<Student>(studentDto)).Returns(student);
            _mapper.Setup(x => x.Map<CourseDto>(course)).Returns(new CourseDto());

            //Act
            await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.AreEqual(1, course.Students.Count);
            Assert.AreEqual("Jonathan", course.Students.FirstOrDefault()?.FirstName);
        }
    }
}
