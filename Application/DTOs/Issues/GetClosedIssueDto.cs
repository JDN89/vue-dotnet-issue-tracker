namespace Application.DTOs.Issues;

public class GetClosedIssueDto: BaseIssueDto
{
    public Guid ClosedIssueId { get; set; }
} 