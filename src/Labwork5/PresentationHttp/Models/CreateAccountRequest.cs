using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PresentationHttp.Models;

public class CreateAccountRequest
{
    [NotNull]
    [Required]
    public string? Password { get; set; }

    [Required]
    public Guid Key { get; set; }
}
