using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UFramework.Encryption;

namespace UFramework.Examples
{
	public class EncryptionAES : MonoBehaviour
	{
		public static string value = "value";
		//private static byte[] valueBytes = Encoding.ASCII.GetBytes(value);
		
		public byte[] encryptedData;

		public void Encrypt()
		{
			AESEncryptor aesEncryptor = new AESEncryptor();
			byte[] iv;
			using (Aes aes = Aes.Create())
			{
				aes.GenerateIV();
				iv = aes.IV;
			}
			byte[] encData = aesEncryptor.Encrypt<string>(value, aesEncryptor.encryptionKeyBytes, iv);
			value = Encoding.ASCII.GetString(encData);
			encryptedData = encData;
		}

		public void Decrypt()
		{
			if (encryptedData == null)
			{
				print("[UFramework] Data is null. Did you run encrypt before this?");
			}
			AESEncryptor aesEncryptor = new AESEncryptor();
			byte[] iv;
			using (Aes aes = Aes.Create())
			{
				aes.Padding = PaddingMode.PKCS7;
				//aes.BlockSize = 128;
				aes.GenerateIV();
				iv = aes.IV;
			}
			string decData = AESEncryptor.Decrypt<string>(encryptedData, aesEncryptor.encryptionKeyBytes, iv);
			print(decData);
			value = decData;
		}
	}
}
