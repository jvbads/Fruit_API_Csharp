using FruitApplication.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication.BussinessLogic
{
    public interface IBLFruit
    {
        Task<IEnumerable<FruitDTOModel>> FindAllAsync();
        Task<FruitDTOModel> FindByIdAsync(long id);
        Task<FruitDTOModel> SaveAsync(FruitDTOModel fruit);
        Task<FruitDTOModel> UpdateAsync(long id, FruitDTOModel fruit);
        Task DeleteAsync(long id);
    }
}
