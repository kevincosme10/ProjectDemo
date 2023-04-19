using FluentValidation;
using ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.CreateClient;

namespace ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.Update
{
  
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} no puede exceder los 50 caracteres");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{LastName} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{LastName} no puede exceder los 50 caracteres");
        }
    }
}
