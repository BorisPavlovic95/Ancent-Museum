using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.TourAggregate
{
    public class Address
    {
        public Address()
        {

        }
        public Address(string firstName, string lastName, string phone, string birthday, string favoriteExhibit, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Birthday = birthday;
            FavoriteExhibit = favoriteExhibit;
            City = city;
        }

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string FavoriteExhibit { get; set; }
        public string City { get; set; }

    }
}
