using FluentValidation;
using MediatR;

namespace SchoolWebSite.Core.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        #region Fields
        private readonly IEnumerable<IValidator<TRequest>> _validators; // I Get List From _validators
        #endregion

        #region Constructor
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        #endregion

        #region Handles Functions
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // check if there any validation or Not 
            // if there any validations keep going
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken))); // lw kol El-validations tmam return [true] else [false]
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select(x => x.PropertyName + ": " + x.ErrorMessage).FirstOrDefault();
                    throw new ValidationException(message);
                }
            }
            return await next();
        }
        #endregion

    }
}

