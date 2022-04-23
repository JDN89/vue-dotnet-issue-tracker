using Application.DTOs.Issues;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Handlers.Issues.Commands;

public class AddNewIssue
{
    public class Command : IRequest<GetOpenIssueDto>
    {
        public AddNewIssueDto Issue { get; set; }
    }

    public class Handler : IRequestHandler<Command, GetOpenIssueDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOpenIssueDto> Handle(Command command, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FindAsync(command.Issue.ProjectId);
            var issue = new OpenIssue
            {
                Id = new Guid(),
                Title = command.Issue.Title,
                Urgency = command.Issue.Urgency,
                Type = command.Issue.Type,
                Description = command.Issue.Description,
                Project = project,
            };

            await _context.OpenIssues.AddAsync(issue, cancellationToken);

            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (success)
            {
                var savedIssue = (_mapper.Map<GetOpenIssueDto>(issue));

                return savedIssue;
            }


            throw new Exception("Problem saving the new Open Issue");
        }
    }
}