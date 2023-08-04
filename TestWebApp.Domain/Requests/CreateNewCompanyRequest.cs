using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TestWebApp.Domain.PostgresEF;

namespace TestWebApp.Domain.Requests;

/// <summary>
/// Request to create new company
/// </summary>
[ExcludeFromCodeCoverage]
public class CreateNewCompanyRequest
{
    /// <summary>
    /// Company name
    /// </summary>
    [Required]
    [StringLength(256)]
    public string? Name { get; set; }

    /// <summary>
    /// Company Employees
    /// </summary>
    public List<Employee> Employees { get; set; }
}