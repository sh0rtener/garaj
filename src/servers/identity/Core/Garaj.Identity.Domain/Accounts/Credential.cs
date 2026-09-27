using Garaj.Identity.Domain.Accounts.Exceptions;
using Garaj.Identity.Domain.Auth;

namespace Garaj.Identity.Domain.Accounts;

public sealed class Credential : Entity<Guid>
{
    public string PasswordHash { get; private set; } = null!;
    public string PasswordSalt { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    private Pbkdf2Sha256Algoritm cypherService = new Pbkdf2Sha256Algoritm();

    public Credential(string password)
    {
        CreatePassword(password);
    }

    public void ChangePassword(string oldPassword, string password)
    {
        ThrowIsInvalidate(oldPassword);
        CreatePassword(password);
    }

    private void CreatePassword(string password)
    {
        var encryptedPair = cypherService.Crypt(password);
        PasswordHash = encryptedPair.Hash;
        PasswordSalt = encryptedPair.Salt;
    }

    public void ThrowIsInvalidate(string password)
    {
        var isValid = cypherService.Validate(password, new(PasswordHash, PasswordSalt));

        if (!isValid)
            throw new InvalidPasswordException();
    }
}
