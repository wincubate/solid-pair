using DI.Basic.Application.Common.Interfaces.Persistence;
using DI.Basic.Application.Common.Interfaces.Services;
using DI.Basic.Domain.Common.Errors;
using DI.Basic.Domain.Entities;
using ErrorOr;

namespace DI.Basic.Application.Services.Companies;

class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CompanyService(
        ICompanyRepository companyRepository,
        IDateTimeProvider dateTimeProvider
    )
    {
        _companyRepository = companyRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public ErrorOr<CreateCompanyResult> Create(
        string cvr,
        string p,
        string name,
        string street,
        string city,
        string zip,
        string country,
        string homepage,
        string email,
        string phone
    )
    {
        if (_companyRepository.GetByCvr(cvr) is not null)
        {
            return Errors.Company.DuplicateCvr;
        }

        Company company = new()
        {
            Cvr = cvr,
            P = p,
            Name = name,
            Address = new CompanyAddress
            {
                Street = street,
                City = city,
                Zip = zip,
                Country = country,
            },
            Contact = new CompanyContact
            {
                Homepage = homepage,
                Email= email,
                Phone = phone
            },
            Created = _dateTimeProvider.UtcNow
        };
        _companyRepository.Add(company);

        return new CreateCompanyResult(company);
    }
}
