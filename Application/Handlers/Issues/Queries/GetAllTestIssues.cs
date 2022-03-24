using Application.DTOs;
using Application.DTOs.User;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Queries;

public class GetAllTestIssues
{
       public class Query : IRequest<List<GetTestIssueDto>>
        {
            public Guid ProjId { get; set; }
        }
       
    public class Handler : IRequestHandler<Query, List<GetTestIssueDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetTestIssueDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var testIssues = _context.TestIssues.Where(x => x.ProjectId == request.ProjId);
            return await testIssues.Select(o => _mapper.Map<GetTestIssueDto>(o))
                .ToListAsync(cancellationToken);
        }
    }
}