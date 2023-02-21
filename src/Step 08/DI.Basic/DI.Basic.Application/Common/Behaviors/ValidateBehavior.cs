using DI.Basic.Application.Companies.Commands;
using DI.Basic.Application.Companies.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace DI.Basic.Application.Common.Behaviors;

public class ValidateBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{

    private readonly IValidator<TRequest>? _validator;
    public ValidateBehavior(
        IValidator<TRequest>? validator = null
    )
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken
    )
    {
        if (_validator is not null)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult
                    .Errors
                    .Select(failure => Error.Validation(
                        code: failure.PropertyName,
                        description: failure.ErrorMessage
                    ))
                    .ToList()
                    ;

                return errors as dynamic;
            }
        }

        return await next();
    }
}
