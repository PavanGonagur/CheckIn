using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Utilities.Interface
{
    public interface INotification
    {
        bool SendNotification(string value);
    }
}
