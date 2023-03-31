﻿using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Common.Models;

public class RunningDto : IMapFrom<Running>
{
    public decimal Distance { get; set; }
    public decimal Speed { get; set; }
    public TimeSpan Cadence { get; set; }
    public TimeSpan Duration { get; set; }
}