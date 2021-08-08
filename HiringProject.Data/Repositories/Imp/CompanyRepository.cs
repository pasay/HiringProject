using HiringProject.Data.DataContext;
using HiringProject.Data.Models;

namespace HiringProject.Data.Repositories.Imp
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbContext context) : base(context)
        {
        }
    }
}
