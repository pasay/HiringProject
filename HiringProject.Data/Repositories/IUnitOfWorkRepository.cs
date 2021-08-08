using System;

namespace HiringProject.Data.Repositories
{
    public interface IUnitOfWorkRepository
    {
        ICompanyRepository CompanyRepository { get; }
        IJobRepository JobRepository { get; }
        IForbiddenWordRepository ForbiddenWordRepository { get; }
    }
}
