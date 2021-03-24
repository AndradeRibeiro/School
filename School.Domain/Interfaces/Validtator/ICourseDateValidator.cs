using School.Domain.Models;

namespace School.Domain.Interfaces.Validtator
{
    public interface ICourseDateValidator
    {
        void ValidateIfExistPeriod(CourseModel courseModel, int id);
    }
}
