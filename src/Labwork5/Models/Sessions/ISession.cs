using Models.ValueObjects;

namespace Models.Sessions;

public interface ISession
{
    SessionKey Key { get; }

    SessionType Type { get; }
}