namespace Garaj.Identity.Domain.Accounts.Exceptions;

public sealed class EmptyCredentialsException : DomainException
{
    private const string _message = "Значение пароля не может быть пустым";

    public EmptyCredentialsException()
        : base(_message) { }
}
