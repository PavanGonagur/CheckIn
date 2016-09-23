using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class ProfileKeyValue
    {
        public int ProfileKeyValueId { get; set; }

        public int ProfileId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
