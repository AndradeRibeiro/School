using FluentValidation;
using System;

namespace School.Domain.Models.FluentValidator
{
    public class CourseModelValidator: AbstractValidator<CourseModel>
    {
        public CourseModelValidator()
        {
            RuleFor(x => x.DescriptionSubject)
                .NotEmpty().WithMessage("Campo descrição do assunto é obrigatório");
            RuleFor(x => x.InitialDate)
                .NotEmpty().WithMessage("Campo data inicial é obrigatório")
                .GreaterThanOrEqualTo(y => DateTime.Now.Date).WithMessage("A data inicial deve ser igual ou maior do que a data atual");
            RuleFor(x => x.FinalDate)
                .NotEmpty().WithMessage("Campo data final é obrigatório");
            RuleFor(x => x.CategoryId)
                .NotNull().GreaterThan(0).WithMessage("Campo id da categoria é obrigatório");
        }
    }
}
