using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;

    public class ContactBusiness : IContactBusiness
    {
        private readonly IContactHandler contactHandler;

        public ContactBusiness()
        {
            this.contactHandler = new ContactHandler();
        }

        public int AddContact(Contact contact)
        {
            var exsitingContactId = this.contactHandler.AddOrUpdateContact(contact);
            if (contact.ContactId != 0)
            {
                return contact.ContactId;
            }
            return exsitingContactId;
        }

        public void DeleteContact(Contact contact)
        {
            this.contactHandler.DeleteContact(contact);
        }

        //if profile not present returning null
        public Contact RetrieveContactById(int contactId)
        {
            return this.contactHandler.RetrieveContactById(contactId);
        }
    }
}