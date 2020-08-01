
using School.Domain.Models;
using System;

namespace School.Domain.Entity
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string DescriptionSubject { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int? NumberStudentsByClass { get; set; }
        public CategoryEntity Category { get; set; }
        public int CategoryId { get; set; }

        public CourseEntity()
        {

        }
        public CourseEntity(int id,
                   string descriptionSubject,
                   DateTime initialDate,
                   DateTime finalDate,
                   int? numberStudentsByClass,
                   int categoryId)
        {
            Id = id;
            DescriptionSubject = descriptionSubject;
            InitialDate = initialDate;
            FinalDate = finalDate;
            NumberStudentsByClass = numberStudentsByClass;
            CategoryId = categoryId;
        }
    }
}
