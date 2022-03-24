using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Commands;

public class DeleteAllOpenIssuesInProject
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
            var replaceOPenIssues = await _context.OpenIssues.Where(o => o.ProjectId == command.ProjectId)
                .ToListAsync(cancellationToken);
            if (replaceOPenIssues.Count<=0) return ;
            
            foreach (var issue in replaceOPenIssues)
            {
                _context.Remove(issue);
            }


            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (success) return;

            throw new Exception("Problem deleting changes");
        }
    }
}