using RunnerTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RunnerTools.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    public DbSet<Workout> Workouts { get; }
    
    public DbSet<WorkoutStep> WorkoutSteps { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
