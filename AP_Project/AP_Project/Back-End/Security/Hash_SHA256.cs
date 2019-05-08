using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AP_Project.Back_End.Security
{
    public class Hash_SHA256
    {
        static public string CreatHash256(string HashString)
        {
            StringBuilder sb = new StringBuilder();
            SHA256 hash = SHA256Managed.Create();
            Encoding enc = Encoding.UTF8;
            byte[] hashbyte = hash.ComputeHash(enc.GetBytes(HashString));
            foreach (byte b in hashbyte)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
