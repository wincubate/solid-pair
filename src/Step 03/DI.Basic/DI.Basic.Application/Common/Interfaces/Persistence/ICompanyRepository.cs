using DI.Basic.Domain.Entities;

namespace DI.Basic.Application.Common.Interfaces.Persistence;

public interface ICompanyRepository
{
    Company? GetByCvr(string cvr);
    void Add(Company company);
}
