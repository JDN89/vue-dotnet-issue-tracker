namespace Application.DTOs.Issues;

public class AddNewIssueDto
{
    
    public string Title { get; set; }
    public string Urgency { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
}