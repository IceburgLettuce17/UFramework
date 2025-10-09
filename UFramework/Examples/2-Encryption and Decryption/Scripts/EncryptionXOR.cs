using UnityEngine;
using UFramework.Encryption;

namespace UFramework.Examples
{
	public class EncryptionXOR : MonoBehaviour 
	{
		public static string value = EncryptionXOR.value;

		public void EncryptDecrypt()
		{
			XOREncryptor xorEncryptor = new XOREncryptor();
			EncryptionXOR.value = xorEncryptor.EncryptDecrypt(value);
		}
	}
}