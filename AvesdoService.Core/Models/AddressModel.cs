using AvesdoService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core.Models
{
    public class Address : IModel<int>
    {
        public int AddressID { get => Id; set => Id = value; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }

        public Address(string street, string city, string province, string country, string postalcode)
        {
            Street = street;
            City = city;
            Province = province;
            Country = country;
            PostalCode = postalcode;
        }


    }
}
