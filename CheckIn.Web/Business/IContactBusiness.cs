using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Models.Channel;

    public interface IContactBusiness
    {
        int AddContact(Contact contact);

        void DeleteContact(Contact contact);

        Contact RetrieveContactById(int contactId);

        List<ContactModel> RetrieveContactsByChannelId(int channelId);
    }
}