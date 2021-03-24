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

        public CourseEntity GetCourseByInitialAndFinalDate(DateTime initialDate, DateTime finalDate, int id)
        {
            return _context.Courses.FirstOrDefault(x => (x.InitialDate.Date == initialDate && x.FinalDate.Date == finalDate.Date && x.Id != id));
        }
    }
}
