using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IOrderRepositoty : IRepository<Order>
    {
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepositoty
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}