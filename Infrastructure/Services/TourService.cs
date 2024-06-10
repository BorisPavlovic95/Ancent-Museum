using Core.Entities;
using Core.Entities.TourAggregate;
using Core.Interfaces;
using Core.Specifications;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TourService : ITourService
    {

        private readonly IPlannerRepository _plannerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public TourService(IPlannerRepository plannerRepo, IUnitOfWork unitOfWork)
        {
            _plannerRepo = plannerRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Tour> CreateTourAsync(string userEmail, string plannerId, Address userData)
        {


            //get basket from the repo
            var planner = await _plannerRepo.GetPlannerAsync(plannerId);
            //get items from the product repo

            var items = new List<TourItem>();
            foreach (var item in planner.Items)
            {
                var exhibitItem = await _unitOfWork.Repository<Exhibits>().GetByIdAsync(item.Id);
                var itemToured = new ExhibitItemToured(exhibitItem.Id, exhibitItem.Name, exhibitItem.PictureUrl);
                var tourItem = new TourItem(itemToured, exhibitItem.Price);
                items.Add(tourItem);
            }
            //calc subtotal
            var subtotal = items.Sum(item => item.Price);
            //create order
            var tour = new Tour(items, userEmail, userData, subtotal);
            _unitOfWork.Repository<Tour>().Add(tour);
            //save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            //delete basket
            await _plannerRepo.DeletePlannerAsync(plannerId);
            //return the order
            return tour;
        }

        public async Task<Tour> GetTourByIdAsync(int id, string userEmail)
        {
            var spec = new ToursWithItemsAndTouringSpecification(id, userEmail);

            return await _unitOfWork.Repository<Tour>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Tour>> GetToursForUserAsync(string userEmail)
        {
            var spec = new ToursWithItemsAndTouringSpecification(userEmail);

            return await _unitOfWork.Repository<Tour>().ListAsync(spec);
        }

        public async Task<Tour> UpdateTourAsync(Tour tour)
        {
            _unitOfWork.Repository<Tour>().Update(tour);
            var result = await _unitOfWork.Complete();

            return result > 0 ? tour : null;
        }


    }
}
