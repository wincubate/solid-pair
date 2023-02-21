using FluentValidation;

namespace DI.Basic.Application.Companies.Commands;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Cvr).Length(8);
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Street).NotEmpty();
        RuleFor(c => c.Zip).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
    }
}
