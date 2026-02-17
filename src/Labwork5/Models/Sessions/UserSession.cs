using Models.ValueObjects;

namespace Models.Sessions;

public class UserSession : ISession
{
    public SessionKey Key { get; }

    public SessionType Type => SessionType.User;

    public AccountNumber AccountNumber { get; }

    public UserSession(SessionKey key,  AccountNumber accountNumber)
    {
        Key = key;
        AccountNumber = accountNumber;
    }
}