

namespace Domain.Entities
{
    public class TestIssue:BaseIssue
    {
       public Guid TestIssueId { get; set; } 
       public Project Project { get; set; }
       public Guid ProjectId { get; set; }
    }
}