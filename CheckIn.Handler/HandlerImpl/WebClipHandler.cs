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
    public class WebClipHandler: IWebClipHandler
    {
        private readonly CheckInDb checkInDb;
        public WebClipHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public int AddOrUpdateWebClip(WebClip webClip)
        {
            this.checkInDb.WebClips.AddOrUpdate(webClip);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.WebClips
                        orderby r.WebClipId descending
                        select r;
            if (query.Any())
            {
                return query.First().WebClipId;
            }
            return 0;
        }

        public List<WebClip> RetrieveWebClipsByChannelId(int channelId)
        {
            var query = this.checkInDb.WebClips.Where(x => x.ChannelId == channelId);
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }

        public WebClip RetrieveWebClipById(int webClipId)
        {
            var query = this.checkInDb.WebClips.Where(x => x.WebClipId == webClipId);
            if (query.Any())
            {
                var currentWebClip = query.FirstOrDefault();
                if (currentWebClip != null)
                {
                    return currentWebClip;
                }
            }
            return null;
        }

        public void DeleteWebClip(WebClip webClip)
        {
            this.checkInDb.WebClips.Remove(webClip);
            this.checkInDb.SaveChanges();
        }
    }
}
