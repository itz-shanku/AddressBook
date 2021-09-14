using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.Controllers
{
    public interface IContactService
    {
        ContactDetails ReturnSpecificContact(int id);
        int ReturnFirstContact();
        int ReturnLastContact();
        List<ContactDetails> ReturnContactList();
        void DeleteSpecificContact(ContactDetails currentContact);
        void UpdateSpecificContact(ContactDetails editedContact);
        void AddNewContact(ContactDetails newUserContact);
    }
}
