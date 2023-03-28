using System.Runtime.Serialization;
using NUnit.Framework;
using AutoMapper;
using RunnerTools.Application.Activities.Queries.GetActivities;
using RunnerTools.Application.Common.Mappings;
using RunnerTools.Application.Common.Models;
using RunnerTools.Application.Records.Queries.GetRecords;
using RunnerTools.Application.Sessions.Queries.GetSessions;
using RunnerTools.Application.Workouts.Queries.ExportWorkouts;
using RunnerTools.Application.Workouts.Queries.GetWorkouts;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config => 
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Workout), typeof(WorkoutDto))]
    [TestCase(typeof(WorkoutStep), typeof(WorkoutStepDto))]
    [TestCase(typeof(Activity), typeof(LookupDto))]
    [TestCase(typeof(Record), typeof(RecordDto))]
    [TestCase(typeof(Session), typeof(SessionDto))]
    [TestCase(typeof(Workout), typeof(LookupDto))]
    [TestCase(typeof(Activity), typeof(ActivityDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}
