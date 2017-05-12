namespace TeduShop.Data.Infrastructure
{
    public class UnitOfWord : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private TeduShopDbContext _dbContext;

        public UnitOfWord(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public TeduShopDbContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}