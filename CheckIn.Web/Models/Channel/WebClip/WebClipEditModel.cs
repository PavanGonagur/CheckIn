﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel.WebClip
{
    public class WebClipEditModel
    {
        public int ChannelId { get; set; }

        public int WebClipId { get; set; }

        public string WebClipName { get; set; }

        public string WebClipUrl { get; set; }

        public string IconUrl { get; set; }

        public bool OpenInBrowser { get; set; }

        public WebClipEditModel()
        {
            
        }
        
        public WebClipEditModel ToModel(CheckIn.Data.Entities.WebClip webClip)
        {
            this.ChannelId = webClip.ChannelId;
            this.WebClipId = webClip.WebClipId;
            this.IconUrl = webClip.IconUrl;
            this.OpenInBrowser = webClip.OpenInBrowser;
            this.WebClipName = webClip.WebClipName;
            this.WebClipUrl = webClip.WebClipUrl;
            return this;
        }

        public CheckIn.Data.Entities.WebClip ToEntity()
        {
            var webclip = new CheckIn.Data.Entities.WebClip()
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