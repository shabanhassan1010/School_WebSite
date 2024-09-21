#region
using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolWebSite.Core.Features.Students.Commands.Models;
using SchoolWebSite.Core.Resourses;
using SchoolWebSite.Services.AbstractMethods;
#endregion

namespace SchoolWebSite.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand> // FluentValidation on <AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResourses> _stringLocalizer;

        #endregion

        #region Constructor
        public AddStudentValidator(IStudentService studentService, IStringLocalizer<SharedResourses> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handle Functions  
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResoursesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResoursesKeys.NotNull])
                .MaximumLength(20).WithMessage(_stringLocalizer[SharedResoursesKeys.MaximumLength]);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResoursesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResoursesKeys.NotNull])
                .MaximumLength(25).WithMessage(_stringLocalizer[SharedResoursesKeys.MaximumLength]);
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResoursesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResoursesKeys.NotNull])
                .MaximumLength(13).WithMessage(_stringLocalizer[SharedResoursesKeys.MaximumLength]);

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResoursesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResoursesKeys.NotNull]);
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExsit(Key))
                .WithMessage(_stringLocalizer[SharedResoursesKeys.NotEmpty]);
        }
        #endregion
    }
}
