using DI.Basic.Application.Common.Interfaces.Persistence;
using DI.Basic.Domain.Entities;

namespace DI.Basic.Application.Services.Companies;

class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    public CreateCompanyResult Create(
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
            string message = $"Company with CVR {cvr} already exists";
            throw new Exception(message); // <-- Never throw generic Exception!!
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
            } 
        };
        _companyRepository.Add(company);

        return new CreateCompanyResult(company);
    }
}
