namespace Garaj.Identity.Domain.Accounts.Exceptions;

public sealed class InvalidAccountLoginException : DomainException
{
    private const string _message = "Неверно указан формат значения логина";

    public InvalidAccountLoginException()
        : base(_message) { }
}
