using Core.Entities.TourAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ToursWithItemsAndTouringSpecification : BaseSpecification<Tour>
    {
        public ToursWithItemsAndTouringSpecification(string email) : base(o => o.UserEmail == email)
        {
            AddInclude(o => o.TourItems);
            AddOrderByDescending(o => o.TourDate);
        }

        public ToursWithItemsAndTouringSpecification(int id, string email) : base(o => o.Id == id && o.UserEmail == email)
        {
            AddInclude(o => o.TourItems);
            
        }
    }
}
