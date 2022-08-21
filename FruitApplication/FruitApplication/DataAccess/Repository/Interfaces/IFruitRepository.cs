using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication
{
    public interface IFruitRepository
    {
        Task<IEnumerable<FruitDTO>> FindAllAsync();
        Task<FruitDTO> FindByIdAsync(long id);
        Task<FruitDTO> SaveAsync(FruitDTO fruitDTO);
        Task<FruitDTO> UpdateAsync(long id, FruitDTO fruitDTO);
        Task DeleteAsync(long id);
    }
}
