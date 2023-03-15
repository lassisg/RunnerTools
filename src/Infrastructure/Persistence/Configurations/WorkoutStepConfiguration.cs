using RunnerTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RunnerTools.Infrastructure.Persistence.Configurations;

public class WorkoutStepConfiguration : IEntityTypeConfiguration<WorkoutStep>
{
    public void Configure(EntityTypeBuilder<WorkoutStep> builder)
    {
        builder.Property(s => s.Index).IsRequired();
        builder.Property(s => s.DurationType).IsRequired();
        builder.Property(s => s.Duration).IsRequired();
        builder.Property(s => s.TargetType).IsRequired();
    }
}