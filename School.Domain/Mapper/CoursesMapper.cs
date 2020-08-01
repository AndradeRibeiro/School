using School.Domain.Entity;
using School.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace School.Domain.Mapper
{
    public static class CoursesMapper
    {
        public static CourseEntity ConvertToEntityRegister(this CourseModel course) =>
            new CourseEntity(0, course.DescriptionSubject, course.InitialDate, course.FinalDate, course.NumberStudentsByClass, course.CategoryId);

        public static CourseEntity ConvertToEntityUpdate(this CourseModel course, int id, CourseEntity courseEntity)
        {
            courseEntity.Id = id;
            courseEntity.DescriptionSubject = course.DescriptionSubject;
            courseEntity.InitialDate = course.InitialDate;
            courseEntity.FinalDate = course.FinalDate;
            courseEntity.NumberStudentsByClass = course.NumberStudentsByClass;
            courseEntity.CategoryId = course.CategoryId;
            return courseEntity;
        }

        public static IEnumerable<CourseModel> ConvertToCourses(this IEnumerable<CourseEntity> courses) =>
            new List<CourseModel>(courses.Select(s => new CourseModel(s.Id, s.DescriptionSubject, s.InitialDate, s.FinalDate, s.NumberStudentsByClass, s.CategoryId)));

        public static CourseModel ConvertToCourse(this CourseEntity course) =>
            new CourseModel(course.Id, course.DescriptionSubject, course.InitialDate, course.FinalDate, course.NumberStudentsByClass, course.CategoryId);
    }
}
