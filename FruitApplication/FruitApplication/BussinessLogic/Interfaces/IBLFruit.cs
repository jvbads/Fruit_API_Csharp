using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication
{
    public interface IBLFruit
    {
        Task<IEnumerable<FruitDTO>> FindAllAsync();
        Task<FruitDTO> FindByIdAsync(long id);
        Task<FruitDTO> SaveAsync(FruitDTO fruit);
        Task<FruitDTO> UpdateAsync(long id, FruitDTO fruit);
        Task DeleteAsync(long id);
    }
}
