using HiringProject.Model.Commands.Jobs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringProject.Business.Rules
{
    public interface IJobQualityRuleCalculator
    {
        IEnumerable<IJobQualityRule> Rules { get; }
        Task<int> CalculateQuality(PostJobCommand newJobCommand);
    }
}
