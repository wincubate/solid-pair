using DI.Basic.Application.Companies.Common;
using ErrorOr;
using MediatR;

namespace DI.Basic.Application.Companies.Queries;

public record GetCompanyQuery(string Cvr)
    : IRequest<ErrorOr<CompanyResult>>
{ }
