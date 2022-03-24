using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClosedIssue : BaseIssue
    {
        public Guid ClosedIssueId { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}