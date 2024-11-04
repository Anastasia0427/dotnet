using Planner.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Planner.DataAccess;

public class PlannerDbContext : DbContext
{
    public DbSet<UserEntity> UserInfo { get; set; }
    public DbSet<BoardEntity> BoardInfo { get; set; }
    public DbSet<ColumnEntity> ColumnInfo { get; set; }
    public DbSet<TaskEntity> TaskInfo { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UrgencyEntity> Urgency { get; set; }
    
    public PlannerDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.UserId);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.UserName).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Email).IsUnique();
        
        modelBuilder.Entity<BoardEntity>().HasKey(x => x.BoardId);
        modelBuilder.Entity<BoardEntity>().HasIndex(x => x. BoardTitle);
        
        modelBuilder.Entity<ColumnEntity>().HasKey(x => x.ColumnId);
        modelBuilder.Entity<ColumnEntity>().HasIndex(x => x.ColumnTitle).IsUnique();
        modelBuilder.Entity<ColumnEntity>().HasIndex(x => x.FKBoardId).IsUnique();
        
        modelBuilder.Entity<TaskEntity>().HasKey(x => x.TaskId);
        modelBuilder.Entity<TaskEntity>().HasIndex(x => x. TaskTitle).IsUnique();
        
        modelBuilder.Entity<RoleEntity>().HasKey(x => x.RoleName);
        
        modelBuilder.Entity<UrgencyEntity>().HasKey(x => x.Urgency);
    }
}