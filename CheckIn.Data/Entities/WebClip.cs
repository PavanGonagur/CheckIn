using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class WebClip
    {
        public int WebClipId { get; set; }

        public string WebClipName { get; set; }

        public string WebClipUrl { get; set; }

        public string IconUrl { get; set; }

        public bool OpenInBrowser { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
