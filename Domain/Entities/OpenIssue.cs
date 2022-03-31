namespace Domain.Entities;

public class OpenIssue : BaseIssue
{
    public Guid Id { get; set; }
    public Project Project { get; set; }
    public Guid ProjectId { get; set; }
}