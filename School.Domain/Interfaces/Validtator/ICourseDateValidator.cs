using School.Domain.Models;

namespace School.Domain.Interfaces.Validtator
{
    public interface ICourseDateValidator
    {
        void ValidateIfExistPeriod(CourseModel courseModel);
        void ValidateIfExistPeriodToUpdate(CourseModel courseModel, int id);
    }
}
