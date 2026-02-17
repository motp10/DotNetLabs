using System.ComponentModel.DataAnnotations;

namespace PresentationHttp.Models;

public class OperationRequest
{
    public decimal Amount { get; set; }

    [Required]
    public Guid Key { get; set; }
}