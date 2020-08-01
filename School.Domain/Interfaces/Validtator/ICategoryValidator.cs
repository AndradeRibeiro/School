
using School.Domain.Models;

namespace School.Domain.Interfaces.Validtator
{
    public interface ICategoryValidator
    {
        void ValidateIfExistCategory(CourseModel courseModel);
    }
}
