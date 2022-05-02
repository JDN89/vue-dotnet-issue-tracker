using Application.DTOs;
using Application.DTOs.Issues;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Handlers.Issues.Commands;

public class AddIssuesInReview
{
     public class Command : IRequest
            {
                public List<GetIssueInReviewDto> Issues { get; set; }
            }
     
         public class Handler : AsyncRequestHandler<Command>
         {
             private readonly DataContext _context;
             private readonly IMapper _mapper;
     
             public Handler(DataContext context, IMapper mapper)
             {
                 _context = context;
                 _mapper = mapper;
             }
     
             protected override async Task Handle(Command command, CancellationToken cancellationToken)
             {
                 var issues = command.Issues.Select(o => _mapper.Map<IssueInReview>(o)).ToList();
     
                 foreach (var issue in issues)
                 {
                     await _context.IssuesInReview.AddAsync(issue, cancellationToken);
                 }
     
                 var success = await _context.SaveChangesAsync(cancellationToken) > 0;
     
                 if (success) return;
     
                 throw new Exception("Problem saving changes");
             }
         }
          
}