using Database.Entities;
using Database.ItlaTVContexts;
using Microsoft.EntityFrameworkCore;

namespace Logica_de_Negocio.Repository
{
    public class ProductoraRepository
    {
        private readonly AppContexts _context;

        public ProductoraRepository(AppContexts context)
        {
            _context = context;
        }

        public async Task AddAsync(Productora productora)
        {
            await _context.Productoras.AddAsync(productora);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Productora productora)
        {
            _context.Entry(productora).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Productora productora)
        {
            _context.Productoras.Remove(productora);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Productora> GetAllAsync()
        {
            return _context.Productoras.AsQueryable();
        }

        public async Task<Productora> GetByIdAsync(int id)
        {
            return await _context.Productoras.FindAsync(id);
        }
    }
}