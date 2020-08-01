using System;

namespace School.Domain.Models
{
    public class CourseModel
    {
        public int Id { get; }
        public string DescriptionSubject { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int? NumberStudentsByClass { get; set; }
        public int CategoryId { get; set; }

        public CourseModel()
        {

        }
        public CourseModel(int id,
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
