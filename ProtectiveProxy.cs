namespace PROXY_PATTERN;


public struct Roles
{
    public const string Admin = "admin";
    public const string User = "user";
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public bool IsDeleted { get; set; }
}

public class Document
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }

    protected Document(string name, string auhtor)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Author = auhtor;
    }

    public virtual void UpdateName(User user, string newName)
    {
        Name = newName;
    }

    public static Document Create(string name, string auhtor)
    {
        return new ProtectedProxyDocument(name, auhtor);
    }

}

public class ProtectedProxyDocument : Document
{
    public ProtectedProxyDocument(string name, string auhtor) : base(name, auhtor)
    {

    }
    public override void UpdateName(User user, string newName)
    {
        if (user.Role != Roles.Admin)
            throw new UnauthorizedAccessException();

        base.UpdateName(user, newName);
    }
}