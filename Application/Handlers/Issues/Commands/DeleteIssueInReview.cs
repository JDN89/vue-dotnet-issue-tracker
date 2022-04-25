
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Commands;

public class DeleteIssueInReview
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
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

            var issue = await _context.IssuesInReview.FirstOrDefaultAsync(o => o.Id == command.Id, cancellationToken);
            if (issue is null) return;

            _context.Remove(issue);



            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (success) return;

            throw new Exception("Problem deleting Issue in review");
        }
    }
}
