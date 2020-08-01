using School.Domain.Entity;
using School.Domain.Interfaces.Repository;
using School.Domain.Interfaces.Validtator;
using School.Domain.Models;
using System;

namespace School.Service.Validators
{
    public class CategoryValidator: ICategoryValidator
    {
        private readonly IBaseRepository<CategoryEntity> _categoryEntity;
        public CategoryValidator(IBaseRepository<CategoryEntity> categoryEntity)
        {
            _categoryEntity = categoryEntity;
        }

        public void ValidateIfExistCategory(CourseModel courseModel)
        {
            var category = _categoryEntity.GetById(courseModel.CategoryId);
            if (category == null)
                throw new Exception("Esta categoria não existe");
        }
    }
}
