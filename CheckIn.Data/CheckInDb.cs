using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIn.Data.Entities;

namespace CheckIn.Data
{
    public class CheckInDb : DbContext
    {
        public CheckInDb()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<UserChannelMap> UserChannelMaps { get; set; }

        public DbSet<AdminChannelMap> AdminChannelMaps { get; set; }

        public DbSet<UserEmailChannel> UserEmailChannels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
