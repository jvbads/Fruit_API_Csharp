using FruitApplication.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication.Repository
{
    public interface IFruitRepository
    {
        Task<IEnumerable<FruitDTOModel>> FindAllAsync();
        Task<FruitDTOModel> FindByIdAsync(long id);
        Task<FruitDTOModel> SaveAsync(FruitDTOModel fruitDTO);
        Task<FruitDTOModel> UpdateAsync(long id, FruitDTOModel fruitDTO);
        Task DeleteAsync(long id);
    }
}
