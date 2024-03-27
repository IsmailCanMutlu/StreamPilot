using Microsoft.EntityFrameworkCore;
using StreamPilot.Data.Models;

namespace StreamPilot.Data.Context;

public class StreamPilotDbContext : DbContext
{
    public StreamPilotDbContext(DbContextOptions<StreamPilotDbContext> options)
        : base(options)
    {
    }
    
    public StreamPilotDbContext()
    {
                
    }
  
    public DbSet<User> Users { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<DataItem> DataItems { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    public DbSet<UserAccess> UserAccesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<UserToken>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.UserTokens)
            .HasForeignKey(ut => ut.UserId);

        
        modelBuilder.Entity<UserAccess>()
            .HasOne(ua => ua.User)
            .WithMany(u => u.UserAccesses)
            .HasForeignKey(ua => ua.UserId);

        modelBuilder.Entity<UserAccess>()
            .HasOne(ua => ua.DataItem)
            .WithMany(di => di.UserAccesses)
            .HasForeignKey(ua => ua.DataItemId);

        
    }
}