namespace Garaj.Identity.Domain.Accounts.Exceptions;

public sealed class InvalidAccountLoginFormatException : DomainException
{
    private const string _message =
        "Выбран неверный параметр для логина. Доступны: Почта, Телефон.";

    public InvalidAccountLoginFormatException()
        : base(_message) { }
}
