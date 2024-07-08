using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class ApplicationContext : DbContext {
    public ApplicationContext(DbContextOptions<ApplicationContext> op) : base(op) {}
    public DbSet<TodoTask> TodoTasks { get; set; }
    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}