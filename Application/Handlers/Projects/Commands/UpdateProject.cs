using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Handlers.Projects.Commands;

public class UpdateProject
{

    public class Command : IRequest<Result<Unit>>
    {
        public GetProjectDto UpdatedProject { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command command, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FindAsync(command.UpdatedProject.ProjectId);
            if (project == null) return null;
            _mapper.Map(command.UpdatedProject, project);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to update activity");

            return Result<Unit>.Success(Unit.Value);

        }

    }
}