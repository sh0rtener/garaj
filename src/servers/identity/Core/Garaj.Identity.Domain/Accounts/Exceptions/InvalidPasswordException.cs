namespace Garaj.Identity.Domain.Accounts.Exceptions;

public sealed class InvalidPasswordException : DomainException
{
    private const string _message = "Неверные данные пользователя";

    public InvalidPasswordException()
        : base(_message) { }
}
