using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
    [RoutePrefix("api/addressbook")]
    public class AddressBookController : ApiController
    {
        private readonly IContactService contactService;
        public AddressBookController(
            IContactService _contactService
            )
        {
            contactService = _contactService;
        }

        [HttpGet]
        [Route("contact/{id}")]
        public ContactDetails GetContact(int id)
        {
            return contactService.ReturnSpecificContact(id);
        }

        [HttpGet]
        [Route("contact/first")]
        public int GetFirstContact()
        {
            return contactService.ReturnFirstContact();
        }

        [HttpGet]
        [Route("contact/last")]
        public int GetLastContact()
        {
            return contactService.ReturnLastContact();
        }

        [HttpGet]
        public List<ContactDetails> GetAllContact()
        {
            return contactService.ReturnContactList();
        }

        [HttpDelete]
        [Route("contact/{id}/delete")]
        public HttpResponseMessage DeleteContact(int id)
        {
            try
            {
                var currentExistingConatct = contactService.FindSpecificContact(id);

                if (currentExistingConatct == null)
                {
                    return ReturnHttpNotFoundStatus(id);
                }
                else
                {
                    contactService.DeleteSpecificContact(currentExistingConatct);

                    return ReturnHttpOKStatus("Contact Deletion Successfull!");
                }
            }
            catch(Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, E);
            }
        }

        [HttpPut]
        [Route("contact/{id}/update")]
        public HttpResponseMessage PutContact(int id, [FromBody]ContactDetails editedContact)
        {
            try
            {
                var currentExistingConatct = contactService.FindSpecificContact(id);

                if (currentExistingConatct == null)
                {
                    return ReturnHttpNotFoundStatus(id);
                }
                else
                {
                    contactService.UpdateSpecificContact(currentExistingConatct, editedContact);

                    return ReturnHttpOKStatus("Contact Updation Successfull!");
                }
            }
            catch(Exception E)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, E);
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage PostContact([FromBody]ContactDetails newUserContact)
        {
            try
            {
                contactService.AddNewContact(newUserContact);

                var responseMessage = Request.CreateResponse(HttpStatusCode.Created, "Contact Addition Successfull!");
                // responseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + newContact.Id.ToString());
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
