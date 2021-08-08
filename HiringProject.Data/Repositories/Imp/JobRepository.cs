using HiringProject.Data.DataContext;
using HiringProject.Data.Models;

namespace HiringProject.Data.Repositories.Imp
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(IDbContext context) : base(context)
        {
        }
    }
}
