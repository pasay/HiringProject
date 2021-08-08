using HiringProject.Model.Commands.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Business.Rules.Imp
{
    public class WorkTypeJobQualityRule : IJobQualityRule
    {
        public int Score => 1;

        public async Task<int> CalculateQuality(PostJobCommand newJobCommand)
        {
            return await Task.FromResult(string.IsNullOrEmpty(newJobCommand.WorkType) ? 0 : Score);
        }
    }
}
