using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;

    public class WebClipModel
    {
        public int WebClipId { get; set; }

        public string WebClipName { get; set; }

        public string WebClipUrl { get; set; }

        public string IconUrl { get; set; }

        public bool OpenInBrowser { get; set; }

        public WebClipModel(WebClip webClip)
        {
            this.WebClipId = webClip.WebClipId;
            this.IconUrl = webClip.IconUrl;
            this.OpenInBrowser = webClip.OpenInBrowser;
            this.WebClipName = webClip.WebClipName;
            this.WebClipUrl = webClip.WebClipUrl;
        }

        public WebClip ToEntity()
        {
            var webclip = new WebClip()
                              {
                                  WebClipId = this.WebClipId,
                                  WebClipName = this.WebClipName,
                                  WebClipUrl = this.WebClipUrl,
                                  IconUrl = this.IconUrl,
                                  OpenInBrowser = this.OpenInBrowser
                              };
            return webclip;
        }
    }
}