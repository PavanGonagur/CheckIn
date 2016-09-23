using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Utilities
{
    public class JsonUtility
    {
        public string JsonInitializer(Stream reqStream)
        {
            reqStream.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(reqStream).ReadToEnd();
            return json;
        }
    }
}