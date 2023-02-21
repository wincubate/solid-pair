using FluentValidation;

namespace DI.Basic.Application.Companies.Queries;

public class GetCompanyQueryValidator : AbstractValidator<GetCompanyQuery>
{
	public GetCompanyQueryValidator()
	{
        RuleFor(c => c.Cvr).Length(8);
    }
}