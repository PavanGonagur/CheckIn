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

        public DbSet<ChatRoom> ChatRooms { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<ProfileKeyValue> ProfileKeyValues { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<WebClip> WebClips { get; set; }

        public DbSet<ChannelBranding> ChannelBrandings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
