namespace Domain.Entities;

public class BaseIssue
{
    public string Title { get; set; }
    public string Urgency { get; set; }
    public DateTime Date { get; set; }
    public string  Type { get; set; }
    public string Description { get; set; }
    
}
