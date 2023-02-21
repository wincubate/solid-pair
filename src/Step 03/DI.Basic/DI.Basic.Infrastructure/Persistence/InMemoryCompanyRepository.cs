using DI.Basic.Application.Common.Interfaces.Persistence;
using DI.Basic.Domain.Entities;

namespace DI.Basic.Infrastructure.Persistence;

public class InMemoryCompanyRepository : ICompanyRepository
{
    private readonly List<Company> _companies;

    public InMemoryCompanyRepository()
    {
        _companies = new List<Company>();
    }

    public Company? GetByCvr(string cvr)
    {
        return _companies.SingleOrDefault( c => c.Cvr == cvr);
    }

    public void Add(Company company)
    {
        _companies.Add(company);
    }
}
