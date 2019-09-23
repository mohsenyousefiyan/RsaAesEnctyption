using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EncryptionTools
{
    public class Enums
    {
        public enum RSAKeySize
        {            
            Key1024 = 1024,
            Key2048 = 2048,
            Key4096 = 4096
        }

        public enum AESKeySize
        {
            Key128 = 128,
            Key192 = 192,
            Key256 = 256
        }
    }
}
