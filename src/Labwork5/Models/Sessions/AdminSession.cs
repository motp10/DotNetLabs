using Models.ValueObjects;

namespace Models.Sessions;

public class AdminSession : ISession
{
    public SessionKey Key { get; }

    public SessionType Type => SessionType.Admin;

    public AdminSession(SessionKey key)
    {
        Key = key;
    }
}