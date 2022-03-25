namespace Application.DTOs.Issues;

public class GetIssueInProgressDto : BaseIssueDto
{
    public Guid InProgressIssueId{ get; set; }
   
}