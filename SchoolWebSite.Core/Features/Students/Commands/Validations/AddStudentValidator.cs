#region
using FluentValidation;
using SchoolWebSite.Core.Features.Students.Commands.Models;
using SchoolWebSite.Services.AbstractMethods;
#endregion

namespace SchoolWebSite.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructor
        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handle Functions  
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must be Not Empty")
                .NotNull().WithMessage("Name  Must be Not Null")
                .MaximumLength(20).WithMessage("MaximumLength Length 20 ");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} Must be Not Empty")
                .NotNull().WithMessage("{PropertyName} Must be Not Null")
                .MaximumLength(25).WithMessage("{PropertyName} Length 25 ");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExsit(Key))
                .WithMessage("Name is Exist");
        }
        #endregion
    }
}
