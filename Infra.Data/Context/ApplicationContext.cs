using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class ApplicationContext : DbContext {
    public DbSet<TodoTask> TodoTasks { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> op) : base(op) {}
    protected override void OnConfiguring(DbContextOptionsBuilder opt) {
        opt.UseNpgsql("Host=localhost;Port=5433;Database=task_manager;Username=docker;Password=123456;");
    }
    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}