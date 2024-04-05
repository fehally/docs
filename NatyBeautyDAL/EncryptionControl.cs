using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NatyBeautyDAL
{
    public static class EncryptionHelper
    {
        private static byte[] Key = Convert.FromBase64String("EpEvz5mItGJxlMYPozskzFepXkpAyoE9Z/VWg4ZiaQs=");
        private static byte[] IV = Convert.FromBase64String("lMAvPX6gvJj8a/OIh3nkNQ==");

        /// <summary>
        /// Method to Encrypt plain text using pre generated Key and IV
        /// </summary>
        /// <param name="plainText">String to be encrypted</param>
        /// <returns>Return Encrypted value for the string</returns>
        public static string Encrypt(string plainText)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");

            using (Aes aesAlg = Aes.Create())
            {
                //aesAlg.GenerateKey();
                //aesAlg.GenerateIV();

                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// Method to Decrypt cypher text using pre generated Key and IV
        /// </summary>
        /// <param name="cipherText">Cypher text to be decrypted</param>
        /// <returns>Return Decrypted value for the cypher text</returns>
        public static string Decrypt(string cipherText)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}