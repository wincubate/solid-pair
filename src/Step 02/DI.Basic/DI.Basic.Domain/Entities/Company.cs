namespace DI.Basic.Domain.Entities;

public class Company
{
    public Guid Id { get; set; } = Guid.NewGuid();
    required public string Cvr { get; set; }
    required public string P { get; set; }
    required public string Name { get; set; }
    required public CompanyAddress Address { get; set; }
    required public CompanyContact Contact { get; set; }
}

public class CompanyAddress
{
    required public string Street { get; set; }
    required public string City { get; set; }
    required public string Zip { get; set; }
    required public string Country { get; set; }
}

public record CompanyContact
{
    required public string Homepage { get; set; }
    required public string Email { get; set; }
    required public string Phone { get; set; }
}


