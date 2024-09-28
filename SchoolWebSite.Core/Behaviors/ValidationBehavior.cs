using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolWebSite.Core.Resourses;

namespace SchoolWebSite.Core.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        #region Fields
        private readonly IEnumerable<IValidator<TRequest>> _validators; // I Get List From _validators
        private readonly IStringLocalizer<SharedResourses> _stringLocalizer;

        #endregion

        #region Constructor
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IStringLocalizer<SharedResourses> stringLocalizer)
        {
            _validators = validators;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Handles Functions
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // check if there any validation or Not 
            // if there any validations keep going
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request); // Create new Obj from request
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken))); // lw kol El-validations tmam return [true] else [false]
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select(x => _stringLocalizer[$"{x.PropertyName}"] + ": " + _stringLocalizer[x.ErrorMessage]).FirstOrDefault();
                    throw new ValidationException(message);
                }
            }
            return await next();
        }
        #endregion

    }
}

