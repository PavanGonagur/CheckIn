using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using System.Data.Entity.Migrations;

    using CheckIn.Data;
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;

    public class ContactHandler:IContactHandler
    {
        private readonly CheckInDb checkInDb;
        public ContactHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public int AddOrUpdateContact(Contact contact)
        {
            this.checkInDb.Contacts.AddOrUpdate(contact);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.Contacts
                        orderby r.ContactId descending
                        select r;
            if (query.Any())
            {
                return query.First().ContactId;
            }
            return 0;
        }

        public List<Contact> RetrieveContactsByChannelId(int channelId)
        {
            var query = this.checkInDb.Contacts.Where(x => x.ChannelId == channelId);
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }

        public Contact RetrieveContactById(int contactId)
        {
            var query = this.checkInDb.Contacts.Where(x => x.ContactId == contactId);
            if (query.Any())
            {
                var currentContact = query.FirstOrDefault();
                if (currentContact != null)
                {
                    return currentContact;
                }
            }
            return null;
        }

        public void DeleteContact(Contact contact)
        {
            this.checkInDb.Contacts.Remove(contact);
            this.checkInDb.SaveChanges();
        }
    }
}
