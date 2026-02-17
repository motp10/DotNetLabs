using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PresentationHttp.Models;

public class CreateAdminSessionRequest
{
    [NotNull]
    [Required]
    public string? Password { get; set; }
}