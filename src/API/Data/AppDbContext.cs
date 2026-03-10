using Microsoft.EntityFrameworkCore;
using EnterpriseServiceRequest.API.Domain.Entities;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<Case> Cases { get; set; }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ServiceRequest> ServiceRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<ServiceRequest>()
            .HasOne(sr => sr.CreatedBy)
            .WithMany()
            .HasForeignKey(sr => sr.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
