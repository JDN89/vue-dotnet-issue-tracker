using System.Text.Json.Serialization;

namespace Domain.Entities;

public class OpenIssue : BaseIssue
{
    public Guid Id { get; set; }
    
    [JsonIgnore] 
    public Project Project { get; set; }
    public Guid ProjectId { get; set; }
}