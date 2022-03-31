

namespace Domain.Entities
{
    public class IssueInReview:BaseIssue
    {
       public Guid Id { get; set; } 
       public Project Project { get; set; }
       public Guid ProjectId { get; set; }
    }
}