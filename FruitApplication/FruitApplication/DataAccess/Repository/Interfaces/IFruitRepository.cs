using FruitApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication.Repository
{
    public interface IFruitRepository
    {
        Task<IEnumerable<Fruit>> FindAllAsync();
        Task<Fruit> FindByIdAsync(long id);
        Task<Fruit> SaveAsync(Fruit fruitDTO);
        Task<Fruit> UpdateAsync(long id, Fruit fruitDTO);
        Task DeleteAsync(long id);
    }
}
