using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ExhibitRepository : IExhibitRepository
    {
        private readonly MuseumContext _context;
        public ExhibitRepository(MuseumContext context)
        {
            _context = context;
        }
        public async Task<Exhibits> GetExhibitByIdAsync(int id)
        {
            return await _context.Exhibits
               .Include(p => p.ExhibitType)
               .Include(p => p.ExhibitCulture)
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ExhibitCulture>> GetExhibitCultureAsync()
        {
            return await _context.ExhibitCulture.ToListAsync();
        }

        public async Task<IReadOnlyList<Exhibits>> GetExhibitsAsync()
        {
            return await _context.Exhibits
               .Include(p => p.ExhibitType)
               .Include(p => p.ExhibitCulture)
               .ToListAsync();
        }

        public async Task<IReadOnlyList<ExhibitType>> GetExhibitTypesAsync()
        {
            return await _context.ExhibitTypes.ToListAsync();
        }
    }
}
