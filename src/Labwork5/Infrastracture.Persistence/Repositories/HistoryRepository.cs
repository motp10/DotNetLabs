using Application.Abstraction.Repositories;
using Models.Operations;
using Models.ValueObjects;

namespace Infrastracture.Persistence.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly Dictionary<AccountNumber, List<Operation>> _values = [];

    public void Add(AccountNumber number, Operation operation)
    {
        if (_values.ContainsKey(number))
        {
            _values[number].Add(operation);
            return;
        }

        _values.Add(number, new List<Operation> { operation });
    }

    public IEnumerable<Operation> QueryByAccountNumber(AccountNumber number)
    {
        return _values.TryGetValue(number, out List<Operation>? list)
            ? list
            : Enumerable.Empty<Operation>();
    }
}