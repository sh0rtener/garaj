using System.Net.Mail;
using System.Text.RegularExpressions;
using Garaj.Identity.Domain.Accounts.Exceptions;

namespace Garaj.Identity.Domain.Accounts;

public static class AccountLoginValidationFactory
{
    public static AccountLoginValidation Create(AccountLoginType type) =>
        type switch
        {
            AccountLoginType.Email => new EmailLoginValidation(),
            AccountLoginType.Phone => new PhoneLoginValidation(),
            _ => throw new InvalidAccountLoginFormatException(),
        };
}

public abstract class AccountLoginValidation
{
    public abstract bool IsValidInput(string input);
}

public sealed class EmailLoginValidation : AccountLoginValidation
{
    public override bool IsValidInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        try
        {
            var email = new MailAddress(input);
            return email.Address == input;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}

public sealed class PhoneLoginValidation : AccountLoginValidation
{
    private static readonly Regex PhoneRegex = new(
        @"^(\+7|8)[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$",
        RegexOptions.Compiled
    );

    public override bool IsValidInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;
        return PhoneRegex.IsMatch(input);
    }
}
