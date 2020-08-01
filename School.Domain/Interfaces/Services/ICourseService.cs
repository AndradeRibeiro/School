
using School.Domain.Models;
using System.Collections.Generic;

namespace School.Domain.Interfaces.Services
{
    public interface ICourseService
    {
        IEnumerable<CourseModel> GetAll();
        CourseModel GetById(int id);
        void Delete(int id);
        void Register(CourseModel courseModel);
        void Update(int id, CourseModel courseModel);
    }
}
