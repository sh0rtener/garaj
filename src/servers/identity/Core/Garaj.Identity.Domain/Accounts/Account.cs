using Garaj.Identity.Domain.Accounts.Exceptions;

namespace Garaj.Identity.Domain.Accounts;

public sealed class Account : Entity<Guid>
{
    public AccountLogin Login { get; private set; } = null!;
    public Credential Credential { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }

    public Account(AccountLogin login, Credential credential)
    {
        if (login is null)
            throw new EmptyAccountLoginException();

        if (credential is null)
            throw new EmptyCredentialsException();

        Login = login;
        Credential = credential;
        CreatedAt = DateTime.UtcNow;
    }
}
