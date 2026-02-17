using Application.Abstraction.Repositories;

namespace Application.Abstraction;

public interface IPersistenceContext
{
    IAccountRepository AccountRepository { get; }

    ISessionsRepository SessionsRepository { get; }

    IHistoryRepository HistoryRepository { get; }

    IAdminPasswordRepository AdminPassword { get; }
}