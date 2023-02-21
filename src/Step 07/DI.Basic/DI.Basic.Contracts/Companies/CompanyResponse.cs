namespace DI.Basic.Contracts.Companies;

public record CompanyResponse(
    Guid Id,
    string Description,
    string Homepage,
    string Email,
    CompanyAddressResponse Address
)
{ }

public record CompanyAddressResponse(
  string AddressLine1,
  string AddressLine2,
  string CountryLine
)
{ }
