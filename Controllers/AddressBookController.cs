using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    [RoutePrefix("Api/AddressBook")]
    public class AddressBookController : ApiController
    {
        StaticData contactList = new StaticData();

        [HttpGet]
        [Route("contact/{id}")]
        public IHttpActionResult GetContact(int id)
        {
            return (IHttpActionResult)contactList.DefaultList.FirstOrDefault(E => E.Id == id);
        }
        [HttpGet]
        public
    }
}
