using School.Domain.Entity;
using School.Domain.Interfaces.Repository;
using School.Domain.Interfaces.Services;
using School.Domain.Interfaces.Validtator;
using School.Domain.Mapper;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly IBaseRepository<CourseEntity> _baseRepository;
        private readonly ICourseValidator _courseValidator;

        public CourseService(IBaseRepository<CourseEntity> baseRepository,
                             ICourseValidator courseValidator)
        {
            _baseRepository = baseRepository;
            _courseValidator = courseValidator;
        }

        public IEnumerable<CourseModel> GetAll()
        {
            var result = _baseRepository.GetAll();
            if(result.Count() != 0)
                return result.ConvertToCourses();
            return null;
        }

        public CourseModel GetById(int id)
        {
            var result = _baseRepository.GetById(id);
            if (result != null)
                return result.ConvertToCourse();
            return null;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public void Register(CourseModel courseModel)
        {
            _courseValidator.ValidateBeforeSave(courseModel);
            var course = courseModel.ConvertToEntityRegister();
            _baseRepository.Save(course);
        }

        public void Update(int id, CourseModel courseModel)
        {
            var entityExist = _baseRepository.GetById(id);
            if (entityExist == null)
                throw new Exception("Este curso não existe");

            _courseValidator.ValidateBeforeUpdate(courseModel, id);
            var course = courseModel.ConvertToEntityUpdate(id, entityExist);
            _baseRepository.Update(course);
        }
    }
}
