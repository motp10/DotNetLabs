namespace Application.Contracts.Models;

public sealed record HistoryDto(IEnumerable<OperationDto> History);