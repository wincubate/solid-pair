using DI.Basic.Application.Common.Interfaces.Persistence;
using DI.Basic.Application.Companies.Common;
using DI.Basic.Domain.Common.Errors;
using DI.Basic.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DI.Basic.Application.Companies.Queries;

public class GetCompanyQueryHandler
    : IRequestHandler<GetCompanyQuery,ErrorOr<CompanyResult>>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyQueryHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository; 
    }

    public Task<ErrorOr<CompanyResult>> Handle(
        GetCompanyQuery query, 
        CancellationToken cancellationToken
    )
    {
        ErrorOr<CompanyResult> result;
        Company? existing = _companyRepository.GetByCvr(query.Cvr);
        if (existing is null)
        {
            result = Errors.Company.CvrNotFound;
        }
        else
        {
            result = new CompanyResult(existing!);
        }

        return Task.FromResult(result);
    }
}
