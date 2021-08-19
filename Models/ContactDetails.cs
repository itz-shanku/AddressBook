using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class ContactDetails {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string LandlineNumber { get; set; }
        public string WebsiteURL { get; set; }
        public string ContactAddress { get; set; }
    }
}