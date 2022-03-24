using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Commands;

public class DeleteIssuesInProgress
{
      public class Command : IRequest
        {
            public Guid ProjectId { get; set; }
        }
      
    public class Handler : AsyncRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
        }

        protected override async Task Handle(Command command, CancellationToken cancellationToken)
        {
            var deleteIssuesInProgress = await _context.inProgressIssues.Where(o => o.ProjectId == command.ProjectId)
                .ToListAsync(cancellationToken);
            if (deleteIssuesInProgress.Count<=0) return ;
            
            foreach (var issue in deleteIssuesInProgress)
            {
                _context.Remove(issue);
            }


            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (success) return;

            throw new Exception("Problem deleting changes");
        }
    }
}