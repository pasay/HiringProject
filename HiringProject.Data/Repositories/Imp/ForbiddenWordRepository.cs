using HiringProject.Data.DataContext;
using HiringProject.Data.Models;

namespace HiringProject.Data.Repositories.Imp
{
    public class ForbiddenWordRepository : RepositoryBase<ForbiddenWord>, IForbiddenWordRepository
    {
        public ForbiddenWordRepository(IDbContext context) : base(context)
        {
        }
    }
}
