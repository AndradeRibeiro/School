using School.Domain.Interfaces.Validtator;
using School.Domain.Models;

namespace School.Service.Validators
{
    public class CourseValidator: ICourseValidator
    {
        private readonly ICategoryValidator _categoryValidator; 
        private readonly ICourseDateValidator _courseDateValidator;
        public CourseValidator(ICategoryValidator categoryValidator,
                               ICourseDateValidator courseDateValidator)
        {
            _categoryValidator = categoryValidator;
            _courseDateValidator = courseDateValidator;
        }
        public void ValidateBeforeSave(CourseModel courseModel)
        {
            _courseDateValidator.ValidateIfExistPeriod(courseModel, courseModel.Id);
            _categoryValidator.ValidateIfExistCategory(courseModel);
        }
    }
}
