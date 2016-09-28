using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;

    public interface IContactBusiness
    {
        int AddContact(Contact contact);

        void DeleteContact(Contact contact);

        Contact RetrieveContactById(int contactId);
    }
}