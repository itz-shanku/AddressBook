using System.Linq;
using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.Controllers
{
    public class ContactService : IContactService
    {
        StaticData contactList = new StaticData();

        public ContactDetails ReturnSpecificContact (int id)
        {
            return contactList.DefaultList.FirstOrDefault(E => E.Id == id);
        }
        public int ReturnFirstContact ()
        {
            return contactList.DefaultList.First().Id;
        }
        public int ReturnLastContact ()
        {
            return contactList.DefaultList.LastOrDefault().Id;
        }
        public List<ContactDetails> ReturnContactList ()
        {
            return contactList.DefaultList;
        }
        public void DeleteSpecificContact (ContactDetails currentContact)
        {
            contactList.DefaultList.Remove(currentContact);
        }
        public void UpdateSpecificContact (ContactDetails currentContact, ContactDetails editedContact)
        {
            currentContact.ContactName = editedContact.ContactName;
            currentContact.Email = editedContact.Email;
            currentContact.MobileNumber = editedContact.MobileNumber;
            currentContact.LandlineNumber = editedContact.LandlineNumber;
            currentContact.WebsiteURL = editedContact.WebsiteURL;
            currentContact.ContactAddress = editedContact.ContactAddress;
        }
        public void AddNewContact (ContactDetails newUserContact)
        {
            var newContact = new ContactDetails();

            newContact.Id = contactList.DefaultList.Count;
            newContact.ContactName = newUserContact.ContactName;
            newContact.Email = newUserContact.Email;
            newContact.MobileNumber = newUserContact.MobileNumber;
            newContact.LandlineNumber = newUserContact.LandlineNumber;
            newContact.WebsiteURL = newUserContact.WebsiteURL;
            newContact.ContactAddress = newContact.ContactAddress;
        }
        public ContactDetails FindSpecificContact (int id)
        {
            return contactList.DefaultList.FirstOrDefault(E => E.Id == id);
        }
    }
}