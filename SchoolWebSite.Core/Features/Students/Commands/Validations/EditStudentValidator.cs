﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolWebSite.Core.Features.Students.Commands.Models;
using SchoolWebSite.Core.Resourses;
using SchoolWebSite.Services.AbstractMethods;

namespace SchoolWebSite.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResourses> _stringLocalizer;
        #endregion

        #region Constructor
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResourses> stringLocalizer)
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

            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResoursesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResoursesKeys.NotNull])
                .MaximumLength(20).WithMessage(_stringLocalizer[SharedResoursesKeys.MaximumLength]);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResoursesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResoursesKeys.NotNull])
                .MaximumLength(25).WithMessage(_stringLocalizer[SharedResoursesKeys.MaximumLength]);
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExsitExcludeSelf(Key, model.Id))
                .WithMessage(_stringLocalizer[SharedResoursesKeys.IsNameExsit]);
            RuleFor(x => x.NameAr)
               .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExsitExcludeSelf(Key, model.Id))
               .WithMessage(_stringLocalizer[SharedResoursesKeys.IsNameExsit]);
        }
        #endregion
    }
}
