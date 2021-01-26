using System.Threading.Tasks;

namespace CommonShop.SalesService.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesDbContext _dbContext;

        public UnitOfWork(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}