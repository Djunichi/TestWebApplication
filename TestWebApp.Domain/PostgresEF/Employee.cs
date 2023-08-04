using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TestWebApp.Domain.Enums;

namespace TestWebApp.Domain.PostgresEF;

/// <summary>
/// 
/// </summary>
[ExcludeFromCodeCoverage]
public class Employee : IValidatableObject
{
    /// <summary>
    /// Company Id
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Employee role
    /// </summary>
    public EEmployeeTitles Title { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Eployee`s companies
    /// </summary>
    public List<Company> Companies { get; set; } = new();

    public override string ToString()
    {
        return "Id : " + Id.ToString()
                       + "Title : " + Enum.GetName(typeof(EEmployeeTitles), Title).ToString()
                       + "Email : " + Email.ToString()
                       + "Crated at : " + CreatedAt.ToString();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var query = Companies.GroupBy(x => x.Name)
        .Where(g => g.Count() > 1)
        .Select(y => y.Key)
        .ToList();

        if (query.Any())
        {
            yield return new ValidationResult("One Employee must be related to one company");
        }
    }
}