using Application.Contracts.Operations;

namespace Application.Contracts.ServicesInterfaces;

public interface ISessionService
{
    CreateUserSession.Response CreateUserSession(CreateUserSession.Request request);

    CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request);
}