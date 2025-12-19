using Application.Contracts.Models;

namespace Application.Mapping;

public class HistoryMappingExtension
{
    public static HistoryDto MapToDto(IEnumerable<OperationDto> history)
    {
        return new HistoryDto(history);
    }
}