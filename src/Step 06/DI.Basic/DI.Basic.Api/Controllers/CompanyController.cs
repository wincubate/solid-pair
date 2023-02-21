using DI.Basic.Application.Companies.Commands;
using DI.Basic.Application.Companies.Common;
using DI.Basic.Application.Companies.Queries;
using DI.Basic.Contracts.Companies;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DI.Basic.Api.Controllers;

[Route("companies")]
public class CompanyController : ApiControllerBase
{
    private readonly ISender _mediator;

    public CompanyController(
        ISender mediator
    )
    {
        _mediator = mediator;
    }

    [HttpPost("get")]
    public async Task<IActionResult> Get(GetCompanyRequest request)
    {
        var query = new GetCompanyQuery(
            request.Cvr
        );

        ErrorOr<CompanyResult> result = await _mediator.Send(query);
        return result.Match(
            value => Ok(value.Company),
            errors => Problem(errors)
        );
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateCompanyRequest request)
    {
        var command = new CreateCompanyCommand(
            request.Cvr,
            request.P,
            request.Name,
            request.Street,
            request.City,
            request.Zip,
            request.Country,
            request.Homepage,
            request.Email,
            request.Phone
        );
        ErrorOr<CompanyResult> result = await _mediator.Send(command);

        return result.Match(
            value => Ok(value.Company),
            errors => Problem(errors)
        );
    }
}