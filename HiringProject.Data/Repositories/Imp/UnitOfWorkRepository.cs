using System;

namespace HiringProject.Data.Repositories.Imp
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public UnitOfWorkRepository(ICompanyRepository companyRepository,
             IJobRepository jobRepository)
        {
            CompanyRepository = companyRepository;
            JobRepository = jobRepository;
        }

        public ICompanyRepository CompanyRepository { get; private set; }

        public IJobRepository JobRepository { get; private set; }
    }
}
