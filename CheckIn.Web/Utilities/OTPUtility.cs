using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Utilities
{
    public class OTPUtility
    {
        public static string GenerateOTP()
        {
            try
            {
                int otpSize = 6;
                Random objrandom = new Random();
                string otp = string.Empty;
                
                for (var counter = 0; counter < otpSize; counter++)
                {
                    int temp = objrandom.Next(0, 9);
                    otp += temp;
                }
                var hashedOtp = HashUtility.GetHash(otp);
                return hashedOtp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}