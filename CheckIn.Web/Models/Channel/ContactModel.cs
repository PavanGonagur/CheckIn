using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;

    public class ContactModel
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        
        public string ContactNumber { get; set; }

        public string Title { get; set; }

        public ContactModel()
        {
            
        }

        public ContactModel(CheckIn.Data.Entities.Contact contact)
        {
            this.ContactName = contact.ContactName;
            this.ContactNumber = contact.ContactNumber;
            this.Title = contact.Title;
            this.ContactId = contact.ContactId;
        }

        public CheckIn.Data.Entities.Contact ToEntity()
        {
            var contact = new CheckIn.Data.Entities.Contact()
                              {
                                  ContactName = this.ContactName,
                                  ContactNumber = this.ContactNumber,
                                  Title = this.Title
                              };
            return contact;
        }
    }
}