using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PS.Mothership.Core.Common.Cryptography
{
    /// <summary>
    /// Encryption and Decruption
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider.decrypt.aspx"/>    
    public sealed class Crypto
    {
        /// <summary>
        /// Encrypt Method
        /// </summary>
        /// <param name="encryptValue"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptValue)
        {
            //Create a UnicodeEncoder to convert between byte array and string.
            var ByteConverter = new UnicodeEncoding();

            //Create byte arrays to hold original, encrypted, and decrypted data. 
            byte[] dataToEncrypt = ByteConverter.GetBytes(encryptValue);

            //Create a new instance of the RSACryptoServiceProvider class  
            // and automatically create a new key-pair.
            var RSAalg = new RSACryptoServiceProvider();

            //Encrypt the byte array and specify no OAEP padding.   
            //OAEP padding is only available on Microsoft Windows XP or 
            //later.  
            byte[] encryptedData = RSAalg.Encrypt(dataToEncrypt, false);

            // return
            return ByteConverter.GetString(encryptedData);
        }

        /// <summary>
        /// Decrupt Method
        /// </summary>
        /// <param name="decryptValue"></param>
        /// <returns></returns>
        public static string Decrypt(string decryptValue)
        {
            //Create a UnicodeEncoder to convert between byte array and string.
            var ByteConverter = new UnicodeEncoding();

            //Create byte arrays to hold original, encrypted, and decrypted data. 
            byte[] dataToDecrypt = ByteConverter.GetBytes(decryptValue);

            //Create a new instance of the RSACryptoServiceProvider class  
            // and automatically create a new key-pair.
            var RSAalg = new RSACryptoServiceProvider();

            //Pass the data to ENCRYPT and boolean flag specifying  
            //no OAEP padding.
            byte[] decryptedData = RSAalg.Decrypt(dataToDecrypt, false);

            // return
            return ByteConverter.GetString(decryptedData);
        }
    }
}
