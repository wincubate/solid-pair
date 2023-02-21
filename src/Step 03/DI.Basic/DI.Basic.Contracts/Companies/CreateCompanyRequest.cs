namespace DI.Basic.Contracts.Companies;

public record CreateCompanyRequest(
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
)
{ }
