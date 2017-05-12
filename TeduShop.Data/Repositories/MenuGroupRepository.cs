using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;

namespace TeduShop.Data.Repositories
{
    public interface IMenuGroupRepository
    {
        
    }
    public class MenuGroupRepository:RepositoryBase<MenuRepository>,IMenuGroupRepository
    {
        public MenuGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
