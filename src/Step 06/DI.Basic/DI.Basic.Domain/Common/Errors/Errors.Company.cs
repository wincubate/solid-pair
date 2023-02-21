using ErrorOr;

namespace DI.Basic.Domain.Common.Errors;

public static partial class Errors
{
    public class Company
    {
        public static Error DuplicateCvr => Error.Validation(
           "Cvr.Duplicate",
           "Company with CVR code already exists."
        );
        public static Error CvrNotFound => Error.NotFound(
           "Cvr.NotFound",
           "Company with CVR does not exist."
        );
    }
}
