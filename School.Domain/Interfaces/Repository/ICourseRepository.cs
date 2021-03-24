using School.Domain.Entity;
using System;

namespace School.Domain.Interfaces.Repository
{
    public interface ICourseRepository
    {
        CourseEntity GetCourseByInitialAndFinalDate(DateTime initialDate, DateTime finalDate, int id);
    }
}
