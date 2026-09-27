using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Garaj.Identity.Domain.Auth;

public sealed record Pbkdf2Sha256Pair(string Hash, string Salt);

public sealed class Pbkdf2Sha256Algoritm
{
    public Pbkdf2Sha256Pair Crypt(string value, string? base64Salt = null)
    {
        byte[] salt = string.IsNullOrEmpty(base64Salt)
            ? CreateSalt(128 / 8)
            : Convert.FromBase64String(base64Salt);
        var hash = KeyDerivation.Pbkdf2(
            password: value,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 600000,
            numBytesRequested: 256 / 8
        );

        return new(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
    }

    public bool Validate(string value, Pbkdf2Sha256Pair existedPair) =>
        CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(Crypt(value, existedPair.Salt).Hash),
            Encoding.UTF8.GetBytes(existedPair.Hash)
        );

    private byte[] CreateSalt(int size) => RandomNumberGenerator.GetBytes(size);
}
