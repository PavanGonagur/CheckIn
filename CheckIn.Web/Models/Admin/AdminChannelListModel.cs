using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Admin
{
    public class AdminChannelListModel
    {
        public int AdminId { get; set; }

        public List<AdminChannelModel> ChannelModels { get; set; }

        public AdminChannelListModel()
        {
            ChannelModels = new List<AdminChannelModel>();
        }

        public AdminChannelListModel(int id)
        {
            AdminId = id;
            ChannelModels = new List<AdminChannelModel>();
        }
    }
}