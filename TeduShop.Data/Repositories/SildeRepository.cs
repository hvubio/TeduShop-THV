using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface ISildeRepository : IRepository<Silde> 
    {
    }

    public class SildeRepository : RepositoryBase<Silde>, ISildeRepository
    {
        public SildeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}