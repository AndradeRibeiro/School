
using FluentValidation.TestHelper;
using School.Domain.Models.FluentValidator;
using System;
using Xunit;

namespace School.Tests.FluentValidator
{

    public class CourseModelValidatorTest: IDisposable
    {
        CourseModelValidator validator;

        public CourseModelValidatorTest()
        {
            validator = new CourseModelValidator();
        }

        [Fact]
        public void Insert_Description_Subject_Null_Fail()
        {
            validator.ShouldHaveValidationErrorFor(course => course.DescriptionSubject, null as string);
        }

        [Fact]
        public void Insert_Description_Subject_Sucess()
        {
            validator.ShouldNotHaveValidationErrorFor(course => course.DescriptionSubject, "Novo curso");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Insert_Category_No_Correct_Fail(int categoryId)
        {
            validator.ShouldHaveValidationErrorFor(course => course.CategoryId, categoryId);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void Insert_Category_Success(int categoryId)
        {
            validator.ShouldNotHaveValidationErrorFor(course => course.CategoryId, categoryId);
        }

        [Fact]
        public void Insert_InitialDate_Null_Fail()
        {
            validator.ShouldHaveValidationErrorFor(course => course.InitialDate, DateTime.MinValue);
        }

        [Fact]
        public void Insert_InitialDate_Invalid_Fail()
        {
            validator.ShouldHaveValidationErrorFor(course => course.InitialDate, new DateTime(2010,10,10));
        }

        [Fact]
        public void Insert_FinalDate_Null_Fail()
        {
            validator.ShouldHaveValidationErrorFor(course => course.FinalDate, DateTime.MinValue);
        }

        [Fact]
        public void Insert_InitialDate_Success()
        {
            validator.ShouldNotHaveValidationErrorFor(course => course.InitialDate, new DateTime(3300, 10,10));
        }

        [Fact]
        public void Insert_FinalDate_Success()
        {
            validator.ShouldNotHaveValidationErrorFor(course => course.InitialDate, new DateTime(3301, 10, 10));
        }

        public void Dispose()
        {
            validator = null;
        }
    }
}
