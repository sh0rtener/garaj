namespace Garaj.Identity.Domain.Accounts;

public sealed class Role : ValueObject
{
    private int _identifier;
    private string _name;

    public string Name => _name;
    public int Identifier => _identifier;
    public static Role Administrator => new(1, "admin");
    public static Role Management => new(2, "manage");
    public static Role Worker => new(3, "worker");

    private Role(int id, string name)
    {
        _identifier = id;
        _name = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Identifier;
        yield return Name;
    }
}
