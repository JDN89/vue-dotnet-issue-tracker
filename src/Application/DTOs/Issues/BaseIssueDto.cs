namespace Application.DTOs.Issues;

public class BaseIssueDto
{
    
    public string Title { get; set; }
    public string Urgency { get; set; }
    public string LocalDate { get => Date.ToString("d"); }
    public string Type { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    
    public DateTime Date { get; set; }
}
