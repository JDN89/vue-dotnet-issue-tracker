using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Handlers.Projects.Commands;

public class AddNewProject
{
    public class Command : IRequest
    {
        public string Title { get; set; }
    }

    public class Handler : AsyncRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        protected override async Task Handle(Command command, CancellationToken cancellationToken)
        {
            var userId = _userAccessor.GetCurrentUserId();
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var newProject = new Project
            {
                Title = command.Title,  
                AppUser = user
            };

            await _context.Projects.AddAsync(newProject, cancellationToken);

            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (success) return;

            throw new Exception("Problem saving changes");
        }
    }
}