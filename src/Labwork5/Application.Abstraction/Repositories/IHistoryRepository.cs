using Models.Operations;
using Models.ValueObjects;

namespace Application.Abstraction.Repositories;

public interface IHistoryRepository
{
    void Add(AccountNumber number, Operation operation);

    IEnumerable<Operation> QueryByAccountNumber(AccountNumber number);
}