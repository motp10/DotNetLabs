using Models.Sessions;
using Models.ValueObjects;

namespace Application.Contracts.Models;

public sealed record SessionDto(SessionKey SessionId, SessionType Type);