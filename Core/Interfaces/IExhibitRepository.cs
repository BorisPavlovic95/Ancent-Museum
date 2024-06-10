using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IExhibitRepository
    {
        Task<Exhibits> GetExhibitByIdAsync(int id);
        Task<IReadOnlyList<Exhibits>> GetExhibitsAsync();

        Task<IReadOnlyList<ExhibitCulture>> GetExhibitCultureAsync();

        Task<IReadOnlyList<ExhibitType>> GetExhibitTypesAsync();
    }
}
