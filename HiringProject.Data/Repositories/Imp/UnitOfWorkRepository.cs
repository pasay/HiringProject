using System;

namespace HiringProject.Data.Repositories.Imp
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public UnitOfWorkRepository(ICompanyRepository companyRepository,
             IJobRepository jobRepository,
             IForbiddenWordRepository forbiddenWordRepository)
        {
            CompanyRepository = companyRepository;
            JobRepository = jobRepository;
            ForbiddenWordRepository = forbiddenWordRepository;
        }

        public ICompanyRepository CompanyRepository { get; private set; }

        public IJobRepository JobRepository { get; private set; }
        public IForbiddenWordRepository ForbiddenWordRepository { get; private set; }
    }
}
