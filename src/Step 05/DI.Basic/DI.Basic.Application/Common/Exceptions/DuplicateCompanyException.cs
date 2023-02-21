using System.Runtime.Serialization;

namespace DI.Basic.Domain.Exceptions;

[Serializable]
public class DuplicateCompanyException : Exception
{
    public DuplicateCompanyException(string? message = null, Exception? inner = null)
        : base(message, inner)
    { }

    protected DuplicateCompanyException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    { }
}
