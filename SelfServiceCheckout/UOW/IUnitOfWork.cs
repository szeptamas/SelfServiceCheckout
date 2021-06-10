using SelfServiceCheckout.Repositories;
using System.Threading.Tasks;

namespace SelfServiceCheckout.UOW
{
    public interface IUnitOfWork
    {
        IMoneyRepository MoneyRepository { get; }
        bool Save();
        Task<bool> SaveAsync();
    }
}