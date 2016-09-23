using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public class HashUtility
    {
        public static string GetHash(string input)
        {
            byte[] hash;
            StringBuilder hashBuilder = new StringBuilder();
            var data = Encoding.UTF8.GetBytes(input);
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(data);
            }

            foreach (byte x in hash)
            {
                hashBuilder.Append(x.ToString("X2"));
            }

            return hashBuilder.ToString();
        }
    }
}