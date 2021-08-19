using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook.Models;

namespace AddressBook.Models
{
    public class StaticData
    {
        public List<ContactDetails> DefaultList = new List<ContactDetails>()
        {
            new ContactDetails()
            {
                Id = 1,
                ContactName = "Chandermani Arora",
                Email = "chandermani@technovert.com",
                MobileNumber = "9292929223",
                LandlineNumber = "4030123121",
                WebsiteURL = "www.technovert.com",
                ContactAddress = "123 now here Some street Madhapur, Hyderabad 500033"
            },
            new ContactDetails()
            {
                Id = 2,
                ContactName = "Sashi Pagadala",
                Email = "sashi@technovert.com",
                MobileNumber = "9292929224",
                LandlineNumber = "4030123121",
                WebsiteURL = "www.technovert.com",
                ContactAddress = "123 now here Some street Madhapur, Hyderabad 500033"
            },
            new ContactDetails()
            {
                Id = 3,
                ContactName = "Praveen Battula",
                Email = "praveen@technovert.com",
                MobileNumber = "9233452342",
                LandlineNumber = "4030123121",
                WebsiteURL = "www.technovert.com",
                ContactAddress = "123 now here Some street Madhapur, Hyderabad 500033"
            },
            new ContactDetails()
            {
                Id = 4,
                ContactName = "Vijay Yalamanchili",
                Email = "vijay@technovert.com",
                MobileNumber = "9292929222",
                LandlineNumber = "4030123121",
                WebsiteURL = "www.technovert.com",
                ContactAddress = "123 now here Some street Madhapur, Hyderabad 500033"
            }
        };
    }
}
