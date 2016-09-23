using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string ProfilePhoteUrl { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string EmailUserName { get; set; }

        public string RegistrationId { get; set; }

        public virtual ICollection<UserChannelMap> UserChannelMaps { get; set; }

        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
