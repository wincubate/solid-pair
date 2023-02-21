using DI.Basic.Application.Companies.Common;

using ErrorOr;
using MediatR;

namespace DI.Basic.Application.Companies.Commands;

public record CreateCompanyCommand(
    string Cvr,
    string P,
    string Name,
    string Street,
    string City,
    string Zip,
    string Country,
    string Homepage,
    string Email,
    string Phone
) : IRequest<ErrorOr<CompanyResult>>
{
}
