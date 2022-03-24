

namespace Domain.Entities
{
    public class InProgressIssue : BaseIssue
    {
       public Guid InProgressIssueId { get; set; } 
       public Project Project { get; set; }
       public Guid ProjectId { get; set; }
    }
}