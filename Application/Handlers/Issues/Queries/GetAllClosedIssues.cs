using Application.DTOs;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Queries;

public class GetAllClosedIssues
{
    public class Query : IRequest<List<GetClosedIssueDto>>
    {
        public Guid ProjId { get; set; }
    }

    public class Handler : IRequestHandler<Query, List<GetClosedIssueDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetClosedIssueDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var closedIssues = _context.ClosedIssues.Where(x => x.ProjectId == request.ProjId);
            return await closedIssues.Select(o => _mapper.Map<GetClosedIssueDto>(o))
                .ToListAsync(cancellationToken);
        }
    }
}