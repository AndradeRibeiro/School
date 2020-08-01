
using AutoFixture;
using Moq;
using School.Domain.Entity;
using School.Domain.Interfaces.Repository;
using School.Domain.Interfaces.Validtator;
using School.Domain.Models;
using School.Service.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace School.Tests.Services
{
    public class CourseServiceTest: IDisposable
    {
        private Mock<IBaseRepository<CourseEntity>> _baseRepository;
        private Mock<ICourseValidator> _courseValidator;
        private Fixture _fixture;

        public CourseServiceTest()
        {
            _baseRepository = new Mock<IBaseRepository<CourseEntity>>();
            _courseValidator = new Mock<ICourseValidator>();
            _fixture = new Fixture();
        }

        [Fact]
        public void GetAll_Courses_Return_List_With_Content()
        {
            var coursesFixture = _fixture.Create<List<CourseEntity>>();

            _baseRepository.Setup(x => x.GetAll()).Returns(coursesFixture);

            CourseService service = new CourseService(_baseRepository.Object, _courseValidator.Object);

            var result = service.GetAll();

            Assert.NotNull(result);
            _baseRepository.Verify(x => x.GetAll(), Times.Once);
        }


        [Fact]
        public void GetAll_Courses_Return_List_Without_Content()
        {

            _baseRepository.Setup(x => x.GetAll()).Returns(new List<CourseEntity>());

            CourseService service = new CourseService(_baseRepository.Object, _courseValidator.Object);

            var result = service.GetAll();

            Assert.Null(result);
            _baseRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_Course_By_Id_Success()
        {
            var courseFixture = _fixture.Create<CourseEntity>();

            _baseRepository.Setup(x => x.GetById(courseFixture.Id)).Returns(courseFixture);

            CourseService service = new CourseService(_baseRepository.Object, _courseValidator.Object);

            var result = service.GetById(courseFixture.Id);

            Assert.NotNull(result);
            Assert.Equal(courseFixture.Id, result.Id);
            _baseRepository.Verify(x => x.GetById(courseFixture.Id), Times.Once);
        }


        [Fact]
        public void Get_Course_By_Id_Return_Without_Content()
        {
            var id = _fixture.Create<int>();
            _baseRepository.Setup(x => x.GetById(id));

            CourseService service = new CourseService(_baseRepository.Object, _courseValidator.Object);

            var result = service.GetById(id);

            Assert.Null(result);
            _baseRepository.Verify(x => x.GetById(id), Times.Once);
        }

        [Fact]
        public void Delete_Course_By_Id_Success()
        {
            var id = _fixture.Create<int>();
            _baseRepository.Setup(x => x.Delete(id));

            CourseService service = new CourseService(_baseRepository.Object, _courseValidator.Object);
            service.Delete(id);

            _baseRepository.Verify(x => x.Delete(id), Times.Once);
        }

        [Fact]
        public void Register_New_Course_Success()
        {
            var courseModel = _fixture.Create<CourseModel>();

            _baseRepository.Setup(x => x.Save(It.IsAny<CourseEntity>()));
            _courseValidator.Setup(x => x.ValidateBeforeSave(courseModel));

            CourseService service = new CourseService(_baseRepository.Object, _courseValidator.Object);
            service.Register(courseModel);

            _baseRepository.Verify(x => x.Save(It.IsAny<CourseEntity>()), Times.Once);
            _courseValidator.Verify(x => x.ValidateBeforeSave(courseModel), Times.Once);
        }

        [Fact]
        public void Update_Course_Success()
        {
            var courseModel = _fixture.Create<CourseModel>();
            var courseFixture = _fixture.Create<CourseEntity>();

            _baseRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(courseFixture);
            _baseRepository.Setup(x => x.Update(It.IsAny<CourseEntity>()));
            _courseValidator.Setup(x => x.ValidateBeforeUpdate(courseModel, courseModel.Id));

            CourseService service = new CourseService(_baseRepository.Object, _courseValidator.Object);
            service.Update(courseModel.Id, courseModel);

            _baseRepository.Verify(x => x.Update(It.IsAny<CourseEntity>()), Times.Once);
            _courseValidator.Verify(x => x.ValidateBeforeUpdate(courseModel, courseModel.Id), Times.Once);
        }

        [Fact]
        public void Update_Course_When_Not_Exist()
        {
            var courseModel = _fixture.Create<CourseModel>();
            var courseFixture = _fixture.Create<CourseEntity>();

            CourseService service = new CourseService(_baseRepository.Object, _courseValidator.Object);
            Exception exception = Assert.Throws<Exception>(() => service.Update(courseModel.Id, courseModel));

            Assert.Equal("Este curso não existe", exception.Message);
        }

        public void Dispose()
        {
            _baseRepository = null;
            _courseValidator = null;
            _fixture = null;
        }
    }
}
