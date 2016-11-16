using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }

        public string Name { get; set; }

        public string ProfilePhoteUrl { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsSuperAdmin { get; set; }

        public bool PasswordResetNeeded { get; set; }

        public virtual ICollection<AdminChannelMap> AdminChannelMaps { get; set; }
    }
}
