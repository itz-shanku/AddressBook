using System.Web.Http;
using AddressBook.Models;
using AddressBook.Service;
using System.Web.Http.Cors;
using System.Collections.Generic;

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
            return contactService.GetSpecificContact(id);
        }

        [HttpGet]
        public List<ContactDetails> GetAllContact()
        {
            return contactService.GetContactList();
        }

        [HttpDelete]
        [Route("contact/{id}/delete")]
        public IHttpActionResult DeleteContact(int id)
        {
           return Ok(contactService.DeleteContact(id));
        }

        [HttpPut]
        [Route("contact/{id}/update")]
        public IHttpActionResult PutContact(int id, [FromBody] ContactDetails editedContact)
        {
            return Ok(contactService.UpdateContact(id, editedContact));
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult PostContact([FromBody] ContactDetails newContact)
        {
            return Ok(contactService.AddContact(newContact));
        }
    }
}
