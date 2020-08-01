using School.Domain.Entity;
using School.Domain.Interfaces.Repository;
using School.Infra.Context;
using System;
using System.Linq;

namespace School.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;
        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public CourseEntity GetCourseByInitialAndFinalDate(DateTime initialDate, DateTime finalDate)
        {
            return _context.Courses.FirstOrDefault(x => (x.InitialDate.Day == initialDate.Day && x.InitialDate.Month == initialDate.Month && x.InitialDate.Year == initialDate.Year) &&
                                                        (x.FinalDate.Day == finalDate.Day && x.FinalDate.Month == finalDate.Month && x.FinalDate.Year == finalDate.Year));
        }
    }
}
