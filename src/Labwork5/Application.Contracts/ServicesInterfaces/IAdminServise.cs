using Application.Contracts.Operations;

namespace Application.Contracts.ServicesInterfaces;

public interface IAdminServise
{
    CreateAccount.Response CreateAccount(CreateAccount.Request request);
}