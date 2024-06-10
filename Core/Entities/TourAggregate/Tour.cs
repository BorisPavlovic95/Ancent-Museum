using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.TourAggregate
{
    public class Tour : BaseEntity
    {
        public Tour(IReadOnlyList<TourItem> tourItems, string userEmail, Address userData, int subtotal)
        {
            UserEmail = userEmail;
            UserData = userData;
            TourItems  = tourItems;
            Subtotal = subtotal;
        }

        public Tour()
        {

        }

        public string UserEmail { get; set; }
        public DateTime TourDate { get; set; } = DateTime.UtcNow;
        [Required]
        public Address UserData { get; set; }
 
        public IReadOnlyList<TourItem> TourItems { get; set; }

        public int Subtotal { get; set; }
        public TourStatus Status { get; set; } = TourStatus.Current;

        public decimal GetTotal()
        {
            return Subtotal;
        }
    }
}
