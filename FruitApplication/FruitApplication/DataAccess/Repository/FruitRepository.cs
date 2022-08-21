using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication
{
    public class FruitRepository : IFruitRepository
    {
        private FruitContext _context;

        public FruitRepository(FruitContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FruitDTO>> FindAllAsync()
        {
            return await _context.Fruits.Include(x => x.Type).ToListAsync();
        }

        public async Task<FruitDTO> FindByIdAsync(long id)
        {
            return await _context.Fruits.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FruitDTO> SaveAsync(FruitDTO fruit)
        {
            try
            {
                var fruitRecorded = await FruitExists(fruit);

                if (fruitRecorded == null)
                {
                    _context.Fruits.Add(fruit);

                    await _context.SaveChangesAsync();

                    return fruit;
                }
                else
                {
                    return fruitRecorded;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<FruitDTO> UpdateAsync(long id, FruitDTO fruit)
        {
            try
            {
                _context.Fruits.Update(fruit);

                await _context.SaveChangesAsync();

                return fruit;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (FruitExists(fruit) == null)
                {
                    throw new ArgumentNullException(nameof(fruit));
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task DeleteAsync(long id)
        {
            if (_context == null)
                throw new ArgumentNullException(nameof(_context));

            var fruit = await _context.Fruits.FindAsync(id);

            if (fruit == null)
                throw new ArgumentNullException(nameof(fruit));

            try
            {
                _context.Fruits.Remove(fruit);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<FruitDTO> FruitExists(FruitDTO fruit)
        {
            return await _context.Fruits.Include(x => x.Type)
                                        .FirstOrDefaultAsync(x => x.Name == fruit.Name && x.Type.Name == fruit.Type.Name);
        }
    }
}
