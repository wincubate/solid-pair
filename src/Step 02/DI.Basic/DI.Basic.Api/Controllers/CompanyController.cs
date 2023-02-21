using DI.Basic.Application.Services.Companies;
using DI.Basic.Contracts.Companies;
using Microsoft.AspNetCore.Mvc;

namespace DI.Basic.Api.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateCompanyRequest request)
        {
            CreateCompanyResult result = _companyService.Create(
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

            return Ok(result.Company);
        }
    }
}
