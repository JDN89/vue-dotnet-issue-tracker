using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Projects.Commands;

public class DeleteProject
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
    public class Handler : IRequestHandler<Command, Result<Unit>>
         {
             private readonly DataContext _context;
     
             public Handler(DataContext context )
             {
                 _context = context;
             }
     
             public async Task<Result<Unit>> Handle(Command command, CancellationToken cancellationToken)
             {
                 var project = await _context.Projects.FindAsync(command.Id);

                 _context.Remove(project);    
                 var result = await _context.SaveChangesAsync() > 0;
                 if (!result) return Result<Unit>.Failure("Failed to delete the activity");

                 return Result<Unit>.Success(Unit.Value);
     
             }
         }
}