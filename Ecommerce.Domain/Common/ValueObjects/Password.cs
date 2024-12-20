namespace Ecommerce.Domain.Common.ValueObjects;

using Ecommerce.Domain.Common.Models;

public class Password(string password) : ValueObject
{
    public string Value { get; set; } = password;
    public static Password Empty { get; } = new Password(string.Empty);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
