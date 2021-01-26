using System.Threading.Tasks;

namespace CommonShop.SalesService.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}