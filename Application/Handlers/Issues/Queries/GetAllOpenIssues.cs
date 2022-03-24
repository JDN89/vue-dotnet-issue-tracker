using Application.DTOs;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Queries;

public class GetAllOpenIssues
{
    public class Query : IRequest<List<GetOpenIssueDto>>
    {
        public Guid ProjId { get; set; }
    }


    public class Handler : IRequestHandler<Query, List<GetOpenIssueDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetOpenIssueDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var openIssues = _context.OpenIssues.Where(x => x.ProjectId == request.ProjId);
            return await openIssues.Select(o => _mapper.Map<GetOpenIssueDto>(o))
                .ToListAsync(cancellationToken);
        }
    }
}