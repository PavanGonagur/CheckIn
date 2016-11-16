using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIn.Web.Models.Purchase;

namespace CheckIn.Web.Business
{
    public interface IPurchaseChannelBusiness
    {
        void AutoProvisionAdminChannel(PurchaseChannelModel purchaseChannelModel);
    }
}
