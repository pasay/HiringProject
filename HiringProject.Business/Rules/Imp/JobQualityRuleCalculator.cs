using HiringProject.Model.Commands.Jobs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringProject.Business.Rules.Imp
{
    public class JobQualityRuleCalculator : IJobQualityRuleCalculator
    {
        public JobQualityRuleCalculator(IEnumerable<IJobQualityRule> rules)
        {
            Rules = rules;
        }

        public IEnumerable<IJobQualityRule> Rules { get; private set; }

        public async Task<int> CalculateQuality(PostJobCommand newJobCommand)
        {
            int quality = 0;
            foreach (var rule in Rules)
            {
                quality += await rule.CalculateQuality(newJobCommand);
            }

            return quality;
        }
    }
}
