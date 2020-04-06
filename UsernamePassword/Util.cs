using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace UsernamePassword
{
    class Util
    {
        public static byte[] HashString(string s)
        {
            byte[] encryptedString;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                //create unicode class for conversion
                UnicodeEncoding ue = new UnicodeEncoding();
                //convert password to array of bytes
                byte[] stringBytes = ue.GetBytes(s);
                //hash to bytearray
                encryptedString = mySHA256.ComputeHash(stringBytes);
            }
            return encryptedString;
        }
    }
}
