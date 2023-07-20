using Application.Common.Errors;
using FluentValidation;
using MediatR;

namespace Application.Common.Behavior
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {

            if (_validator is null) return await next();

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
                return await next();

            var errors = validationResult.Errors
                .Select(validationFailure => validationFailure.ErrorMessage).ToList();

            throw new ValidationExeption() { StatusCode = System.Net.HttpStatusCode.BadRequest, ErrorMessage = string.Join(",", errors) };
        }
    }
}