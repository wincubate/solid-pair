namespace DI.Basic.Contracts.Companies;

public record CompanyResponse(
    Guid Id,
    string Cvr,
    string P,
    string Name,
    CompanyAddressResponse Address,
    CompanyContactResponse Contact
)
{ }

public record CompanyAddressResponse(
  string Street,
  string City,
  string Zip,
  string Country
)
{ }

public record CompanyContactResponse(
   string Homepage,
   string Email,
   string Phone
)
{ }
