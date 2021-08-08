using System;

namespace HiringProject.Data.Repositories
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IJobRepository JobRepository { get; }
    }
}
