namespace Application.DTOs.Issues;

public class UpdateIssueDto
{
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Urgency { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
}