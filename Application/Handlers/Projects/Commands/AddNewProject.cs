using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Projects.Commands;

public class AddNewProject
{
    public class Command : IRequest<Result<GetProjectDto>>
    {
        public GetProjectDto NewProject { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<GetProjectDto>>
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

        public async Task<Result<GetProjectDto>> Handle(Command command, CancellationToken cancellationToken)
        {
            var userId = _userAccessor.GetCurrentUserId();
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            var newProject = (_mapper.Map<Project>(command.NewProject));
            newProject.AppUser = user;

            await _context.Projects.AddAsync(newProject, cancellationToken);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<GetProjectDto>.Failure("Failed to update activity");
            
            var savedProject = await _context.Projects.SingleOrDefaultAsync(p => p.Title == newProject.Title);
           
            var savedProjectDto = (_mapper.Map<GetProjectDto>(savedProject));
                return Result<GetProjectDto>.Success(savedProjectDto);

        }
    }
}