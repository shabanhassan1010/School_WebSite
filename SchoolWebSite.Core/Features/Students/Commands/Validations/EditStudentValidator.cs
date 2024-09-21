using FluentValidation;
using SchoolWebSite.Core.Features.Students.Commands.Models;
using SchoolWebSite.Services.AbstractMethods;

namespace SchoolWebSite.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructor
        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handle Functions  
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameEn)
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
            //RuleFor(x => x.DepartmentId)
            //    .MustAsync(async (Key, CancellationToken) => await _studentService.IsDepartmentIdExsit(Key))
            //    .WithMessage("DepartmentId is Not Exist");
        }
        #endregion
    }
}
