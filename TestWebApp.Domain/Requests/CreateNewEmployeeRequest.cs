using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TestWebApp.Domain.Enums;
using TestWebApp.Domain.PostgresEF;

namespace TestWebApp.Domain.Requests;

/// <summary>
/// Request to Create New Employee
/// </summary>
[ExcludeFromCodeCoverage]
public class CreateNewEmployeeRequest
{
    /// <summary>
    /// Employee role
    /// </summary>
    [Required]
    public EEmployeeTitles Title { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [StringLength(256)]
    public string? Email { get; set; }

    /// <summary>
    /// List of companites
    /// </summary>
    public List<Company> Companies { get; set; }
}