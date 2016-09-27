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

    public class ApplicationHandler
    {
        private readonly CheckInDb checkInDb;
        public ApplicationHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public int AddOrUpdateApplication(Application application)
        {
            this.checkInDb.Applications.AddOrUpdate(application);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.Applications
                        orderby r.ApplicationId descending
                        select r;
            if (query.Any())
            {
                return query.First().ApplicationId;
            }
            return 0;
        }

        public List<Application> RetrieveApplicationsByChannelId(int channelId)
        {
            var query = this.checkInDb.Applications.Where(x => x.ChannelId == channelId);
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }

        public Application RetrieveApplicationById(int applicationId)
        {
            var query = this.checkInDb.Applications.Where(x => x.ApplicationId == applicationId);
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

        public void DeleteApplication(Application application)
        {
            this.checkInDb.Applications.Remove(application);
            this.checkInDb.SaveChanges();
        }
    }
}
