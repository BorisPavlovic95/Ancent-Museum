using Core.Entities.TourAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITourService
    {
        Task<Tour> CreateTourAsync(string userEmail, string plannerId, Address userData);

        Task<IReadOnlyList<Tour>> GetToursForUserAsync(string userEmail);

        Task<Tour> GetTourByIdAsync(int id, string userEmail);

        Task<Tour> UpdateTourAsync(Tour tour);



    }
}
