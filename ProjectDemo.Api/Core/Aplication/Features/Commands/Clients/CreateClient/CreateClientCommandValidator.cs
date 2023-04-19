using FluentValidation;

namespace ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.CreateClient
{
    
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
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
