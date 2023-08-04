using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TestWebApp.Domain.PostgresEF;

/// <summary>
/// Company
/// </summary>
[ExcludeFromCodeCoverage]
public class Company : IValidatableObject
{
    /// <summary>
    /// Company Id
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Company name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Company`s employees
    /// </summary>
    public List<Employee> Employees { get; set; } = new();

    public override string ToString()
    {
        return "Id : " + Id.ToString()
                       + "Name : " + Name.ToString()
                       + "CreatedAt : " + CreatedAt.ToString();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var query = Employees.GroupBy(x => x.Email)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList();

        if (query.Any())
        {
            yield return new ValidationResult("One Company must be related to one employee");
        }
        
        var query2 = Employees.GroupBy(x => x.Title)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList();

        if (query.Any())
        {
            yield return new ValidationResult("One Company must be related to one employee title");
        }
    }
}