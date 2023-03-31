﻿using RunnerTools.Application.Common.Mappings;

namespace RunnerTools.Application.Common.Models;

public class RunningDurationDto : IMapFrom<RunningDto>
{
    public decimal Distance { get; set; }
    public decimal Speed { get; set; }
    public TimeSpan Cadence { get; set; }
    public TimeSpan Duration { get; set; }
}