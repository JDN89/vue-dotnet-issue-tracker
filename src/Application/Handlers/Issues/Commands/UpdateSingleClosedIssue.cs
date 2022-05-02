

using Application.DTOs.Issues;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Commands;

public class UpdateSingleClosedIssue
{
    public class Command : IRequest<Unit>
    {
        public UpdateIssueDto Issue { get; set; }
    }


    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var issue = await _context.ClosedIssues.FirstOrDefaultAsync(o => o.Id == command.Issue.Id, cancellationToken);
            if (issue is null)
            {
                throw new Exception("closed issue not found in db");
            }
            else
            {
                issue.Description = command.Issue.Description;
                issue.Title = command.Issue.Title;
                issue.Type = command.Issue.Type;
                issue.Urgency = command.Issue.Urgency;
            }


            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (success) return Unit.Value;

            throw new Exception("failed to update the closed Issue ");
        }
    }
}
