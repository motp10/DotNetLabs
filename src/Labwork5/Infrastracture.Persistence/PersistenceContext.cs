using Application.Abstraction;
using Application.Abstraction.Repositories;

namespace Infrastracture.Persistence;

public class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(
        IAccountRepository accountRepository,
        ISessionsRepository sessionsRepository,
        IHistoryRepository historyRepository,
        IAdminPasswordRepository adminPasswordRepository)
    {
        AccountRepository = accountRepository;
        SessionsRepository = sessionsRepository;
        HistoryRepository = historyRepository;
        AdminPassword = adminPasswordRepository;
    }

    public IAccountRepository AccountRepository { get; }

    public ISessionsRepository SessionsRepository { get; }

    public IHistoryRepository HistoryRepository { get; }

    public IAdminPasswordRepository AdminPassword { get; }
}