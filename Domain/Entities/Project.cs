namespace Domain.Entities;

public class Project
{
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
    public AppUser AppUser { get; set; }
    public ICollection<OpenIssue> OpenIssues { get; set; }
    public ICollection<InProgressIssue> InProgressIssues{ get; set; }
    public ICollection<TestIssue> TestIssues { get; set; }
    public ICollection<ClosedIssue> ClosedIssues { get; set; }
}