using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DataContext : IdentityDbContext<AppUser>
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Project> Projects { get; set; }
    public DbSet<OpenIssue> OpenIssues { get; set; }
    public DbSet<InProgressIssue> inProgressIssues { get; set; }
    public DbSet<TestIssue> TestIssues { get; set; }
    public DbSet<ClosedIssue> ClosedIssues { get; set; }



}