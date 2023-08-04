using System.Diagnostics.CodeAnalysis;
using TestWebApp.Domain.Enums;

namespace TestWebApp.Domain.PostgresEF;

/// <summary>
/// Log record
/// </summary>
[ExcludeFromCodeCoverage]
public class SystemLog
{
    /// <summary>
    /// Log Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Resource entity
    /// </summary>
    public string Resource { get; set; }

    /// <summary>
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Type of event
    /// </summary>
    public EEventType EventType { get; set; }
    
    /// <summary>
    /// Attributes of Entity
    /// </summary>
    public string Attributes { get; set; }

    /// <summary>
    /// Comment
    /// </summary>
    public string Comment { get; set; }
}