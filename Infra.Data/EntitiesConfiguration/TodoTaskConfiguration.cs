using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration;

public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask> {
    public void Configure(EntityTypeBuilder<TodoTask> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Code).HasMaxLength(6).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();

        builder.HasData(
            new TodoTask("Task Test",  0, "")
        );
    }
}