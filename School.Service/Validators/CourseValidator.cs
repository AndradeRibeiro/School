using School.Domain.Entity;
using School.Domain.Interfaces.Repository;
using School.Domain.Interfaces.Validtator;
using School.Domain.Models;

namespace School.Service.Validators
{
    public class CourseValidator: ICourseValidator
    {
        private readonly ICategoryValidator _categoryValidator; 
        private readonly ICourseDateValidator _courseDateValidator;
        public CourseValidator(ICategoryValidator categoryValidator,
                               IBaseRepository<CategoryEntity> categoryEntity,
                               ICourseDateValidator courseDateValidator)
        {
            _categoryValidator = categoryValidator;
            _courseDateValidator = courseDateValidator;
        }
        public void ValidateBeforeSave(CourseModel courseModel)
        {
            _courseDateValidator.ValidateIfExistPeriod(courseModel);
            _categoryValidator.ValidateIfExistCategory(courseModel);
        }

        public void ValidateBeforeUpdate(CourseModel courseModel, int id)
        {
            _courseDateValidator.ValidateIfExistPeriodToUpdate(courseModel, id);
            _categoryValidator.ValidateIfExistCategory(courseModel);
        }
    }
}
