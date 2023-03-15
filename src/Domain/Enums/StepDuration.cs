namespace RunnerTools.Domain.Enums;

public enum StepDuration
{
    Time = 0,
    Distance = 1,
    HrLessThan = 2,
    HrGreaterThan = 3,
    Calories = 4,
    Open = 5,
    RepeatUntilStepsComplete = 6,
    RepeatUntilTime = 7,
    RepeatUntilDistance = 8,
    RepeatUntilCalories = 9,
    RepeatUntilHrLessThan = 10,
    RepeatUntilHrGreaterThan = 11,
    TrainingPeaksTss = 12,
    RepeatUntilTrainingPeaksTss = 13,
    RepetitionTime = 14,
    Reps = 15,
    TimeOnly = 16,
    Invalid = 99
}