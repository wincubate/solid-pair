using ErrorOr;

namespace DI.Basic.Domain.Common.Errors;

public static partial class Errors
{
    public class Company
    {
        public static Error DuplicateCvr => Error.Validation(
           "Duplicate.Cvr",
           "Company with CVR code already exists."
        );
    }
}
