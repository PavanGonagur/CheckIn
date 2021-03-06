﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class UserChannelMap
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int ChannelId { get; set; }

        public virtual User User { get; set; }

        public virtual Channel Channel { get; set; }

        public string Otp { get; set; }

        public string EmailId { get; set; }
    }
}
