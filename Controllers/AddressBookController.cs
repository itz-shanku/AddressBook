using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddressBook.Models;
using System.Web.Http.Cors;
namespace AddressBook.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
    [Route("api/addressbook")]
    public class AddressBookController : ApiController
    {
        StaticData contactList = new StaticData();

        [HttpGet]
        [Route("contact/{id}")]
        public ContactDetails GetContact(int id)
        {
            return contactList.DefaultList.FirstOrDefault(E => E.Id == id);
        }

        [HttpGet]
        public List<ContactDetails> GetAllContact()
        {
            return contactList.DefaultList;
        }

        [HttpDelete]
        public HttpResponseMessage DeleteContact(int id)
        {
            try
            {
                var currentExistingConatct = contactList.DefaultList.FirstOrDefault(E => E.Id == id);

                if (currentExistingConatct == null)
                {
                    return ReturnHttpNotFoundStatus(id);
                }
                else
                {
                    contactList.DefaultList.Remove(currentExistingConatct);

                    return ReturnHttpOKStatus("Contact Deletion Successfull!");
                }
            }
            catch(Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, E);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutContact(int id, [FromBody]ContactDetails editedContact)
        {
            try
            {
                var currentExistingConatct = contactList.DefaultList.FirstOrDefault(E => E.Id == id);

                if (currentExistingConatct == null)
                {
                    return ReturnHttpNotFoundStatus(id);
                }
                else
                {
                    currentExistingConatct.ContactName = editedContact.ContactName;
                    currentExistingConatct.Email = editedContact.Email;
                    currentExistingConatct.MobileNumber = editedContact.MobileNumber;
                    currentExistingConatct.LandlineNumber = editedContact.LandlineNumber;
                    currentExistingConatct.WebsiteURL = editedContact.WebsiteURL;
                    currentExistingConatct.ContactAddress = editedContact.ContactAddress;

                    return ReturnHttpOKStatus("Contact Updation Successfull!");
                }
            }
            catch(Exception E)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, E);
            }
        }

        [HttpPost]
        public HttpResponseMessage PostContact([FromBody]ContactDetails newUserContact)
        {
            try
            {
                var newContact = new ContactDetails();

                newContact.Id = contactList.DefaultList.Count;
                newContact.ContactName = newUserContact.ContactName;
                newContact.Email = newUserContact.Email;
                newContact.MobileNumber = newUserContact.MobileNumber;
                newContact.LandlineNumber = newUserContact.LandlineNumber;
                newContact.WebsiteURL = newUserContact.WebsiteURL;
                newContact.ContactAddress = newContact.ContactAddress;

                var responseMessage = Request.CreateResponse(HttpStatusCode.Created, "Contact Addition Successfull!");
                responseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + newContact.Id.ToString());
                return responseMessage;
            }
            catch(Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, E);
            }
        }
        private HttpResponseMessage ReturnHttpNotFoundStatus(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Given contact id: " + id.ToString() + " not found.");
        }
        private HttpResponseMessage ReturnHttpOKStatus(string responseMessage)
        {
            return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
        }
    }
}
