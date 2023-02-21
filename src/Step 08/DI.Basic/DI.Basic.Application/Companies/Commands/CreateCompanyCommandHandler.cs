using DI.Basic.Application.Common.Interfaces.Persistence;
using DI.Basic.Application.Common.Interfaces.Services;
using DI.Basic.Application.Companies.Common;
using DI.Basic.Domain.Common.Errors;
using DI.Basic.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DI.Basic.Application.Companies.Commands;

public class CreateCompanyCommandHandler
    : IRequestHandler<CreateCompanyCommand, ErrorOr<CompanyResult>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    public CreateCompanyCommandHandler(
        ICompanyRepository companyRepository,
        IDateTimeProvider dateTimeProvider
    )
    {
        _companyRepository = companyRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task<ErrorOr<CompanyResult>> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        ErrorOr<CompanyResult> result;

        if (_companyRepository.GetByCvr(command.Cvr) is not null)
        {
            result = Errors.Company.DuplicateCvr;
        }
        else
        {
            Company company = new()
            {
                Cvr = command.Cvr,
                P = command.P,
                Name = command.Name,
                Address = new CompanyAddress
                {
                    Street = command.Street,
                    City = command.City,
                    Zip = command.Zip,
                    Country = command.Country,
                },
                Contact = new CompanyContact
                {
                    Homepage = command.Homepage,
                    Email = command.Email,
                    Phone = command.Phone
                },
                Created = _dateTimeProvider.UtcNow
            };
            _companyRepository.Add(company);
            result = new CompanyResult(company);
        }

        return Task.FromResult(result);
    }
}
