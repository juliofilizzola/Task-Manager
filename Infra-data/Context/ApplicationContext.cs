using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra_data.Context;

public class ApplicationContext : DbContext {
    public DbSet<TodoTask> TodoTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder opt) {
        opt.UseNpgsql("");
    }
}