using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Projects.Queries;

public class GetAllProjects
{
    public class Query : IRequest<List<GetProjectDto>>

    {
    }

    public class Handler : IRequestHandler<Query, List<GetProjectDto>>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
        {
            _context = context;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<List<GetProjectDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var userId = _userAccessor.GetCurrentUserId();
            var projects = _context.Projects.Where(x => x.AppUser.Id == userId);
            return await projects.Select(p => _mapper.Map<GetProjectDto>(p))
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}