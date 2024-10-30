using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeFit.Models;

namespace BeFit.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<BeFit.Models.Session> Session { get; set; } = default!;

public DbSet<BeFit.Models.ExcersizeType> ExcersizeType { get; set; } = default!;

public DbSet<BeFit.Models.Excersize> Excersize { get; set; } = default!;
}