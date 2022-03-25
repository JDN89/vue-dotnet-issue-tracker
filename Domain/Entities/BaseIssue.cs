using System.ComponentModel;

namespace Domain.Entities;

public class BaseIssue
{
    public string Title { get; set; }
    public string Urgency { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string  Type { get; set; }
    public string Description { get; set; }
    
}
