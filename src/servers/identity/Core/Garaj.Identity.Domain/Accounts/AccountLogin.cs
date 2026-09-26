using Garaj.Identity.Domain.Accounts.Exceptions;

namespace Garaj.Identity.Domain.Accounts;

public enum AccountLoginType
{
    Email = 1,
    Phone = 2,
}

public sealed class AccountLogin : ValueObject
{
    private readonly AccountLoginType _type;
    private readonly string _value;

    public AccountLoginType Type => _type;
    public string Value => _value;

    public AccountLogin(AccountLoginType type, string value)
    {
        _type = type;

        var valueValidator = AccountLoginValidationFactory.Create(type);
        if (!valueValidator.IsValidInput(value))
            throw new InvalidAccountLoginException();

        _value = AccountLoginFormatterFactory.Create(type).Format(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return Value;
    }
}
