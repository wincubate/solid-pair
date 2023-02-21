using DI.Basic.Contracts.Companies;
using DI.Basic.Domain.Entities;

namespace DI.Basic.Api.Common.Mapping.Companies;

public static class CompanyMappingExtensions
{
    public static CompanyResponse ToResponse(this Company company) =>
        new CompanyResponse
        (
            Id: company.Id,
            Description: $"{company.Name} [CVR: {company.Cvr}]",
            Email: company.Contact.Email,
            Homepage: company.Contact.Homepage,
            Address: company.Address.ToResponse()
        );

    public static CompanyAddressResponse ToResponse(this CompanyAddress address) =>
        new CompanyAddressResponse
        (
            AddressLine1: address.Street,
            AddressLine2: $"{address.Zip} {address.City}",
            CountryLine: address.Country
        );
}
