﻿using FluentValidation;
using MediatR;
using ValidationException = ProjectDemo.Api.Core.Aplication.Exceptions.ValidationException;

namespace ProjectDemo.Api.Core.Aplication.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validators = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
    //public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    //{
    //    private readonly IEnumerable<IValidator<TRequest>> _validators;

    //    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    //    {
    //        _validators = validators;
    //    }

    //    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    //    {
    //        if (_validators.Any())
    //        {
    //            var context = new ValidationContext<TRequest>(request);

    //            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

    //            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

    //            if (failures.Count != 0)
    //            {
    //                throw new ValidationException(failures);
    //            }

    //        }

    //        return await next();
    //    }


    //}
}
