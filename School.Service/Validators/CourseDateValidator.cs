using School.Domain.Entity;
using School.Domain.Interfaces.Repository;
using School.Domain.Interfaces.Validtator;
using School.Domain.Models;
using System;

namespace School.Service.Validators
{
    public class CourseDateValidator: ICourseDateValidator
    {
        private readonly ICourseRepository _courseRepository;
        public CourseDateValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void ValidateIfExistPeriod(CourseModel courseModel, int id = 0)
        {
            var courseEntity = GetCourseByInitialAndFinalDate(courseModel, id);
            if (courseEntity != null)
                throw new Exception("Existe(m) curso(s) planejados(s) dentro do período informado.");
        }

        private CourseEntity GetCourseByInitialAndFinalDate(CourseModel courseModel, int id)
        {
            return _courseRepository.GetCourseByInitialAndFinalDate(courseModel.InitialDate, courseModel.FinalDate, id);
        }
    }
}
