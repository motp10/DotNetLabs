using Models.Sessions;
using Models.ValueObjects;

namespace Application.Abstraction.Repositories;

public interface ISessionsRepository
{
    void Add(SessionKey key, ISession session);

    IEnumerable<ISession> Query(SessionKey key);
}