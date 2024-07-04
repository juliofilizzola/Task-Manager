using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class ApplicationContext : DbContext {
    public DbSet<TodoTask> TodoTasks { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> op) : base(op) {}
    protected override void OnConfiguring(DbContextOptionsBuilder opt) {
        opt.UseNpgsql("Host=task-manager-db-prod-juliofilizzola.g.aivencloud.com;Database=defaultdb;Port=26577;Username=avnadmin;Password=AVNS_He4E4_I_vr86bz9ZVJQ;");
    }
    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}