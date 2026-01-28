using Application.Abstraction.Repositories;
using Models.ValueObjects;

namespace Infrastracture.Persistence.Repositories;

public class AdminPasswordRepository : IAdminPasswordRepository
{
    public Password Password { get; private set; } = new Password("admin");
}