using School.Domain.Models;

namespace School.Domain.Interfaces.Validtator
{
    public interface ICourseValidator
    {
        void ValidateBeforeSave(CourseModel courseModel);
        void ValidateBeforeUpdate(CourseModel courseModel, int id);
    }
}
