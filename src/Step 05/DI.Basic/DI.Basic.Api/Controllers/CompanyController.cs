using DI.Basic.Application.Services.Companies;
using DI.Basic.Contracts.Companies;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DI.Basic.Api.Controllers;

[Route("companies")]
public class CompanyController : ApiControllerBase
{
    private readonly ICompanyService _companyService;
    
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost("create")]
    public IActionResult Create(CreateCompanyRequest request)
    {
        ErrorOr<CreateCompanyResult> result = _companyService.Create(
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

        return result.Match(
            value => Ok(value.Company),
            errors => Problem(errors)
        );
    }
}
