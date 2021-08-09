using HiringProject.Model.Commands.Jobs;
using System.Threading.Tasks;

namespace HiringProject.Business.Rules.Imp
{
    public class FringeBenefitsJobQualityRule : IJobQualityRule
    {
        public int Score => 1;

        public async Task<int> CalculateQuality(PostJobCommand newJobCommand)
        {
            return await Task.FromResult(string.IsNullOrEmpty(newJobCommand.FringeBenefits) ? 0 : Score);
        }
    }
}
