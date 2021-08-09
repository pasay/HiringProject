using HiringProject.Model.Commands.Jobs;
using System.Threading.Tasks;

namespace HiringProject.Business.Rules.Imp
{
    public class SalaryJobQualityRule : IJobQualityRule
    {
        public int Score => 1;

        public async Task<int> CalculateQuality(PostJobCommand newJobCommand)
        {
            return await Task.FromResult((newJobCommand.Salary <= 0) ? 0 : Score);
        }
    }
}
