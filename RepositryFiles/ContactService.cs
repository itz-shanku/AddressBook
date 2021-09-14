using System.Linq;
using AddressBook.Models;
using System.Collections.Generic;
using PetaPoco;

namespace AddressBook.Controllers
{
    public class ContactService : IContactService
    {

        Database dataContext;
        public ContactService()
        {
            dataContext = new Database("AddressBookDB");
        }

        StaticData contactList = new StaticData();

        public ContactDetails ReturnSpecificContact (int id)
        {
            return dataContext.FirstOrDefault<ContactDetails>($"SELECT * FROM CONTACTS WHERE Id ={id}");
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
            return dataContext.Fetch<ContactDetails>("SELECT * FROM CONTACTS");
        }
        public void DeleteSpecificContact (ContactDetails currentContact)
        {
            dataContext.Delete(currentContact);
        }
        public void UpdateSpecificContact (ContactDetails editedContact)
        {
            dataContext.Update(editedContact);
        }
        public void AddNewContact (ContactDetails newUserContact)
        {
            dataContext.Insert(newUserContact);
        }
    }
}