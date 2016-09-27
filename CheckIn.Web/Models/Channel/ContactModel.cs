using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;

    public class ContactModel
    {
        public string ContactName { get; set; }
        
        public string ContactNumber { get; set; }

        public string Title { get; set; }

        public ContactModel(Contact contact)
        {
            this.ContactName = contact.ContactName;
            this.ContactNumber = contact.ContactNumber;
            this.Title = contact.Title;
        }

        public Contact ToEntity()
        {
            var contact = new Contact()
                              {
                                  ContactName = this.ContactName,
                                  ContactNumber = this.ContactNumber,
                                  Title = this.Title
                              };
            return contact;
        }
    }
}