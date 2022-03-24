using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Issues.Commands;

public class DeleteIssuesInReview
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
             var deleteIssuesInReview= await _context.TestIssues.Where(o => o.ProjectId == command.ProjectId)
                 .ToListAsync(cancellationToken);
             if (deleteIssuesInReview.Count<=0) return ;
             
             foreach (var issue in deleteIssuesInReview)
             {
                 _context.Remove(issue);
             }
 
 
             var success = await _context.SaveChangesAsync(cancellationToken) > 0;
 
             if (success) return;
 
             throw new Exception("Problem deleting changes");
         }
     }     
}