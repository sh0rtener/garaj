namespace Garaj.Identity.Domain.Accounts.Exceptions;

public sealed class EmptyAccountLoginException : DomainException
{
    private const string _message = "Значение логина не может быть пустым";

    public EmptyAccountLoginException()
        : base(_message) { }
}
