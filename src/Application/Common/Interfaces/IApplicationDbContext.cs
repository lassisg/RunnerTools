using RunnerTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RunnerTools.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Workout> Workouts { get; }
    
    public DbSet<WorkoutStep> WorkoutSteps { get; }
    
    public DbSet<Activity> Activities { get; }
    
    public DbSet<Session> Sessions { get; }
    
    public DbSet<Lap> Laps { get; }
    
    public DbSet<Record> Records { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
