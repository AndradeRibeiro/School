
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using School.API.Controllers;
using School.Domain.Interfaces.Services;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace School.Tests.Controllers
{
    public class CourseControllerTest : IDisposable
    {
        private Mock<ICourseService> _courseService;
        private Fixture _fixture;
        public CourseControllerTest()
        {
            _courseService = new Mock<ICourseService>();
            _fixture = new Fixture();
        }

        [Fact]
        public void Register_NewCourse_Success()
        {
            var courseFixture = _fixture.Create<CourseModel>();
            _courseService.Setup(x => x.Register(courseFixture));
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.Register(courseFixture) as OkResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Register_NewCourse_Fail()
        {
            var courseFixture = _fixture.Create<CourseModel>();
            _courseService.Setup(x => x.Register(courseFixture)).Throws(new Exception("Error"));
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.Register(courseFixture) as BadRequestObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void Update_Course_Success()
        {
            var courseFixture = _fixture.Create<CourseModel>();
            var id = _fixture.Create<int>();

            _courseService.Setup(x => x.Update(id, courseFixture));
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.Update(id, courseFixture) as OkResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Update_Course_Fail()
        {
            var courseFixture = _fixture.Create<CourseModel>();
            var id = _fixture.Create<int>();

            _courseService.Setup(x => x.Update(id, courseFixture)).Throws(new Exception("Error"));
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.Update(id, courseFixture) as BadRequestObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void GetAll_Courses_Success()
        {
            var coursesFixture = _fixture.Create<List<CourseModel>>();

            _courseService.Setup(x => x.GetAll()).Returns(coursesFixture);
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.GetAll() as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void GetAll_Courses_Fail()
        {
            _courseService.Setup(x => x.GetAll()).Throws(new Exception("Error"));
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.GetAll() as BadRequestObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void Get_Course_By_Id_Success()
        {
            var courseFixture = _fixture.Create<CourseModel>();
            var id = _fixture.Create<int>();

            _courseService.Setup(x => x.GetById(id)).Returns(courseFixture);
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.GetById(id) as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Get_Course_By_Id_Fail()
        {
            var id = _fixture.Create<int>();
            _courseService.Setup(x => x.GetById(id)).Throws(new Exception("Error"));
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.GetById(id) as BadRequestObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void Delete_Course_By_Id_Success()
        {
            var id = _fixture.Create<int>();

            _courseService.Setup(x => x.Delete(id));
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.Delete(id) as OkResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Delete_Course_By_Id_Fail()
        {
            var id = _fixture.Create<int>();
            _courseService.Setup(x => x.Delete(id)).Throws(new Exception("Error"));
            CoursesController controller = new CoursesController(_courseService.Object);

            var result = controller.Delete(id) as BadRequestObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        public void Dispose()
        {
            _courseService = null;
            _fixture = null;
        }
    }
}
