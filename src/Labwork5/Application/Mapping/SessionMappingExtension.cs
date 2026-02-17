using Application.Contracts.Models;
using Models.Sessions;
using Models.ValueObjects;

namespace Application.Mapping;

public class SessionMappingExtension
{
    public static SessionDto MapToDto(SessionKey sessionKey, SessionType sessionType)
    {
        return new SessionDto(sessionKey, sessionType);
    }
}