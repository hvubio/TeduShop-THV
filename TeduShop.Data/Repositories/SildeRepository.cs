using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface ISildeRepository
    {
        
    }
    public class SildeRepository :RepositoryBase<Silde>, ISildeRepository
    {
        public SildeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
