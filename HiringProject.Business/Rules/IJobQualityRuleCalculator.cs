﻿using HiringProject.Model.Commands.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Business.Rules
{
    public interface IJobQualityRuleCalculator
    {
        IEnumerable<IJobQualityRule> Rules { get; }
        Task<int> CalculateQuality(PostJobCommand newJobCommand);
    }
}
