using Application.Contracts.Operations;

namespace Application.Contracts.ServicesInterfaces;

public interface IUserServise
{
    DoOperation.Response GetBalance(DoOperation.Request request);

    DoOperation.Response Deposit(DoOperation.Request request);

    DoOperation.Response WithDraw(DoOperation.Request request);

    GetHistory.Response OperationHistory(GetHistory.Request request);
}