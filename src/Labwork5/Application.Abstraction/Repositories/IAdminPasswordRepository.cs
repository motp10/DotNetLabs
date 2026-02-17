using Models.ValueObjects;

namespace Application.Abstraction.Repositories;

public interface IAdminPasswordRepository
{
    Password Password { get; }
}