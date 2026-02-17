using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PresentationHttp.Models;

public class CreateUserSessionRequest
{
    [NotNull]
    public string? Password { get; set; }

    [Required]
    public Guid Number { get; set; }
}