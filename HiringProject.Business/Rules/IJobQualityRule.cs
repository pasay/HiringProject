using HiringProject.Model.Commands.Jobs;
using System.Threading.Tasks;

namespace HiringProject.Business.Rules
{
    public interface IJobQualityRule
    {
        int Score { get; }
        Task<int> CalculateQuality(PostJobCommand newJobCommand);
    }
}
