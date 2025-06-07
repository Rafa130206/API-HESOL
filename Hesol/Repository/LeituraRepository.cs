using Hesol.Connection;
using Hesol.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace Hesol.Repository
{
    public class LeituraRepository
    {
        private readonly AppDbContext _context;

        public LeituraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Leitura>> GetAllAsync()
        {
            return await _context.Leitura.ToListAsync();
        }

        public async Task<Leitura?> GetByIdAsync(int id)
        {
            return await _context.Leitura.FindAsync(id);
        }

        public async Task AddAsync(Leitura leitura)
        {
            _context.Leitura.Add(leitura);
            await _context.SaveChangesAsync();
            Console.WriteLine(">> String de conexão usada: " + _context.Database.GetDbConnection().ConnectionString);

        }

        public async Task UpdateAsync(Leitura leitura)
        {
            _context.Entry(leitura).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Leitura leitura)
        {
            _context.Leitura.Remove(leitura);
            await _context.SaveChangesAsync();
        }

    }
}

