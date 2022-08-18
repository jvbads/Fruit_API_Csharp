using FruitApplication.DataAccess.Utils;
using FruitApplication.Entities;
using FruitApplication.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication.DataAccess.Repository
{
    public class FruitRepository : IFruitRepository
    {
        private FruitContext _context;

        public FruitRepository(FruitContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FruitDTOModel>> FindAllAsync()
        {
            return await _context.Fruits.ToListAsync();
        }

        public async Task<FruitDTOModel> FindByIdAsync(long id)
        {
            return await _context.Fruits.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FruitDTOModel> SaveAsync(FruitDTOModel fruit)
        {
            if (fruit == null)
                throw new Exception("fruit resquested to save does not exist.");

            try
            {
                _context.Fruits.Add(fruit);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fruit;
        }

        public async Task<FruitDTOModel> UpdateAsync(long id, FruitDTOModel fruit)
        {
            if (fruit.Id != id)
                throw new ArgumentException("Id can not be the same to update.");

            try
            {
                _context.Update(fruit);

                await _context.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fruit;
        }

        public async Task DeleteAsync(long id)
        {
            if (_context == null)
                throw new ArgumentNullException("_context");

            var fruit = await _context.Fruits.FindAsync(id);

            if (fruit == null)
                throw new Exception("fruit id resquested to delete does not exist.");

            _context.Remove(fruit);

            await _context.SaveChangesAsync();
        }
    }
}
