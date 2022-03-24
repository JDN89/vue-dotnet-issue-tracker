using Application.DTOs;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Queries;

public class GetAllIssuesInProgress
{
    public class Query : IRequest<List<GetIssueInProgressDto>>
    {
        public Guid ProjId { get; set; }
    }

    public class Handler : IRequestHandler<Query, List<GetIssueInProgressDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetIssueInProgressDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var issuesInProgress = _context.inProgressIssues.Where(x => x.ProjectId == request.ProjId);
            return await issuesInProgress.Select(o => _mapper.Map<GetIssueInProgressDto>(o))
                .ToListAsync(cancellationToken);
        }
    }
}