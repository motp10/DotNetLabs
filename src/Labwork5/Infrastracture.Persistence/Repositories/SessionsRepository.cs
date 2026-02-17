using Application.Abstraction.Repositories;
using Models.Sessions;
using Models.ValueObjects;

namespace Infrastracture.Persistence.Repositories;

public class SessionsRepository : ISessionsRepository
{
    private readonly Dictionary<SessionKey, ISession> _values = [];

    public void Add(SessionKey key, ISession session)
    {
        if (_values.ContainsKey(key)) throw new Exception("Session already exists");
        _values[key] = session;
    }

    public IEnumerable<ISession> Query(SessionKey key)
    {
        return _values
            .Where(pair => pair.Key.Equals(key))
            .Select(pair => pair.Value);
    }
}