using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IContactHandler
    {
        void DeleteContact(Contact contact);

        Contact RetrieveContactById(int contactId);

        List<Contact> RetrieveContactsByChannelId(int channelId);

        int AddOrUpdateContact(Contact contact);
    }
}
