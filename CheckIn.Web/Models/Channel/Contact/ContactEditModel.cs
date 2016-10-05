using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel.Contact
{
    using System.ComponentModel.DataAnnotations;

    public class ContactEditModel
    {
        public int ContactId { get; set; }

        public int ChannelId { get; set; }

        [Required]
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        [DisplayName("Title")]
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
                ChannelId = ChannelId,
                ContactId = ContactId,
                ContactName = this.ContactName,
                ContactNumber = this.ContactNumber,
                Title = this.Title
            };
            return contact;
        }
    }
}