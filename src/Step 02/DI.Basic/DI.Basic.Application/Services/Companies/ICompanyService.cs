namespace DI.Basic.Application.Services.Companies;

public interface ICompanyService
{
    CreateCompanyResult Create(
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
    );
}
