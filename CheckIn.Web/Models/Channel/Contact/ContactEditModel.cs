﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel.Contact
{
    public class ContactEditModel
    {
        public int ContactId { get; set; }

        public int ChannelId { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }

        public string Title { get; set; }

        public ContactEditModel()
        {
            
        }

        public ContactEditModel ToModel(CheckIn.Data.Entities.Contact contact)
        {
            this.ContactId = contact.ContactId;
            this.ChannelId = contact.ChannelId;
            this.ContactName = contact.ContactName;
            this.ContactNumber = contact.ContactNumber;
            this.Title = contact.Title;
            return this;
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