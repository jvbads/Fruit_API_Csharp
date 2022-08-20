using FruitApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication.BussinessLogic
{
    public interface IBLFruit
    {
        Task<IEnumerable<Fruit>> FindAllAsync();
        Task<Fruit> FindByIdAsync(long id);
        Task<Fruit> SaveAsync(Fruit fruit);
        Task<Fruit> UpdateAsync(long id, Fruit fruit);
        Task DeleteAsync(long id);
    }
}
