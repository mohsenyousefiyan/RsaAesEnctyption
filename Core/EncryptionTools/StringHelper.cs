using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.EncryptionTools
{
    public class StringHelper
    {
        public static string GetBase64(string text)
        {
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            }
            catch
            {
                return null;
            }
        }
        public static string GetBase64(byte[] Data)
        {
            try
            {
                return Convert.ToBase64String(Data);
            }
            catch
            {
                return null;
            }
        }
        public static byte[]Base64ToByteArray(string Base64)
        {
            try
            {
                return Convert.FromBase64String(Base64);
            }
            catch
            {
                return null;
            }
        }

        public static string ByteArrayToString(byte[]Data)
        {
            try
            {
                return Encoding.UTF8.GetString(Data);
            }
            catch
            {
                return null;
            }
        }
        public static byte[] StringToByteArray(string txt)
        {
            try
            {
                return Encoding.UTF8.GetBytes(txt);
            }
            catch
            {
                return null;
            }
        }

        public static StreamReader StringToStreamReader(string txt)
        {
            var bytearray = StringToByteArray(txt);
            MemoryStream stream = new MemoryStream(bytearray);
            StreamReader reader = new StreamReader(stream);
            return reader;
        }
    }
}
