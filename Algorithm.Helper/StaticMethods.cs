using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Algorithm.Helper
{
    public static class StaticMethods
    {
        static readonly byte[] encryptSalt = new byte[] { 0x35, 0x59, 0x27, 0x48 };
        private const string encryptKey = "!BatucanMalik!";

        public static string ConvertToBase64(object obj, bool encrypt = false, string encryptKey = encryptKey)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memoryStream, obj);
                string base64 = Convert.ToBase64String(memoryStream.ToArray());

                if (encrypt)
                {
                    var encrypted = Encrypt(Encoding.UTF8.GetBytes(base64), encryptKey);
                    base64 = Convert.ToBase64String(encrypted);
                }
                return base64;
            }
        }
        public static object ConvertFromBase64(string base64, bool encrypt = false, string encryptKey = encryptKey)
        {
            byte[] bytes = Convert.FromBase64String(base64);

            if (encrypt)
            {
                var encrypted = Encoding.UTF8.GetString(Decrypt(bytes, encryptKey));
                bytes = Convert.FromBase64String(encrypted);
            }
            using (MemoryStream memoryStream = new MemoryStream(bytes, 0, bytes.Length))
            {
                memoryStream.Write(bytes, 0, bytes.Length);
                memoryStream.Position = 0;
                return new BinaryFormatter().Deserialize(memoryStream);
            }
        }

        public static byte[] Encrypt(byte[] input, string encryptKey)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(encryptKey, encryptSalt);
            MemoryStream ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            CryptoStream cs = new CryptoStream(ms,
              aes.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }
        public static byte[] Decrypt(byte[] input, string encryptKey)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(encryptKey, encryptSalt);
            MemoryStream ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            CryptoStream cs = new CryptoStream(ms,
              aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }
    }
}
