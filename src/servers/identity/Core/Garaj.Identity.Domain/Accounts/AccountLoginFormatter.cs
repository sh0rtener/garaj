using Garaj.Identity.Domain.Accounts.Exceptions;

namespace Garaj.Identity.Domain.Accounts;

public static class AccountLoginFormatterFactory
{
    public static AccountLoginFormatter Create(AccountLoginType type) =>
        type switch
        {
            AccountLoginType.Email => new EmailLoginFormatter(),
            AccountLoginType.Phone => new PhoneLoginFormatter(),
            _ => throw new InvalidAccountLoginFormatException(),
        };
}

public abstract class AccountLoginFormatter
{
    public virtual string Format(string input) => input;
}

public sealed class PhoneLoginFormatter : AccountLoginFormatter
{
    public override string Format(string input)
    {
        if (input[0].Equals('8'))
            input = "7" + input[1..];
        return input
            .Trim()
            .Replace("(", "")
            .Replace(")", "")
            .Replace("-", "")
            .Replace("+", "")
            .Replace(" ", "");
    }
}

public sealed class EmailLoginFormatter : AccountLoginFormatter
{
    public override string Format(string input)
    {
        return input.ToLowerInvariant().Trim();
    }
}
