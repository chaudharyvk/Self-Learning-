using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerApi.Models
{
    public class Customer
    {

        public Customer()
        {

        }
        public Customer(int id,string name,int age,string address, int postalcode,string city,string country)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
            PostoCode = postalcode;
            City = city;
            Country = country;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int PostoCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}