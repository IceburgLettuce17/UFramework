
namespace UFramework.Encryption
{
	// Class responsible for XOR encryption
	public class XOREncryptor
	{
		public const string encryptionKey = "u{f+r~a>m|e-?w&o%r^k";

		public string EncryptDecrypt(string data)
		{
			string modData = "";
			for (int i = 0; i < data.Length; i++)
			{
				modData += (char) (data[i] ^ encryptionKey[i % encryptionKey.Length]);
			}
			return modData;
		}
	}
}