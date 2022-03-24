namespace Application.DTOs;

public class GetOpenIssueDto
{
    public Guid OpenIssueId { get; set; }
    public string Title { get; set; }
    public string Urgency { get; set; }
    public DateTime Date { get; set; }
    public string  Type { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
}