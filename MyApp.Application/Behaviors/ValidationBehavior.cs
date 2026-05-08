using FluentValidation;
using MediatR;
using MyApp.Application.Exceptions;

namespace MyApp.Application.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        private readonly IValidator<TRequest>[] _validators = validators.ToArray();

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validators.Length == 0)
            {
                return await next(cancellationToken);
            }

            var context = new ValidationContext<TRequest>(request);

            FluentValidation.Results.ValidationFailure[] failures = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure is not null)
                .ToArray();

            if (failures.Length != 0)
            {
                Dictionary<string, string[]> failureDictionary = failures
                    .GroupBy(f => string.IsNullOrWhiteSpace(f.PropertyName) ? "_" : f.PropertyName)
                    .ToDictionary(group => group.Key,
                        group => group.Select(error => error.ErrorMessage).Distinct().ToArray());

                throw new ApplicationValidationException(failureDictionary);
            }

            return await next(cancellationToken);
        }
    }
}
