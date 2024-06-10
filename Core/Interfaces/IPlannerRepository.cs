using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPlannerRepository
    {
        Task<Planner> GetPlannerAsync(string plannerId);

        Task<Planner> UpdatePlannerAsync(Planner planner);

        Task<bool> DeletePlannerAsync(string plannerId);
    }
}
