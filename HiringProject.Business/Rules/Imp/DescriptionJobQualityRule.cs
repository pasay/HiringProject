using HiringProject.Data.Repositories;
using HiringProject.Model.Commands.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Business.Rules.Imp
{
    public class DescriptionJobQualityRule : IJobQualityRule
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public DescriptionJobQualityRule(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Score => 2;

        public async Task<int> CalculateQuality(PostJobCommand newJobCommand)
        {
            //TODO: Sakıncalı kelimeler için ELK sorgulaması eklenecek.
            var forbiddenWords = await _unitOfWork.ForbiddenWordRepository.GetAsync();
            return (newJobCommand.Description.Split(new string[] { " "}, StringSplitOptions.RemoveEmptyEntries).Any(p=> forbiddenWords.Any(f=> f.Word.Equals(p)))) ? 0 : Score;
        }
    }
}
