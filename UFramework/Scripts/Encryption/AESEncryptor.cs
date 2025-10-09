using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Text;
using UnityEngine;

namespace UFramework.Encryption
{
	// Class responsible for AES encryption
	public class AESEncryptor
	{
		// Keys
		public const string encryptionKey = "I15MYfyOmheINNJ/RD8DTg==";
		public byte[] encryptionKeyBytes;

		public AESEncryptor()
		{
			encryptionKeyBytes = Encoding.UTF8.GetBytes(encryptionKey);
		}
		
		// Encrypt data
		public byte[] Encrypt<T>(T data, byte[] encKey, byte[] iv)
		{
			encKey = encryptionKeyBytes;
			try
			{
				byte[] raw;
				BinaryFormatter binFormatter = new BinaryFormatter();
				using (MemoryStream stream = new MemoryStream())
				{
					 binFormatter.Serialize(stream, data);
                     raw = stream.ToArray();
				}
				
				using (Aes aes = Aes.Create())
				{
					aes.Key = encKey;
					aes.IV = iv;
					
					ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
					
					using (MemoryStream encStream = new MemoryStream())
					{
						using (CryptoStream cs = new CryptoStream(encStream, encryptor, CryptoStreamMode.Write))
						{
							cs.Write(raw, 0, raw.Length);
							return encStream.ToArray();
						}	
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("[UFramework] AES Encryption failed! Error: " + ex.Message);
				Debug.Log("Key: " + encKey);
				return null;
				
			}
		}
		
		// Decrypt data
		public static T Decrypt<T>(byte[] data, byte[] key, byte[] iv)
		{
			key = new AESEncryptor().encryptionKeyBytes;
			try
			{
				using (Aes aes = Aes.Create())
				{
					aes.Key = key;
					aes.IV = iv;
					ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
					using (MemoryStream stream = new MemoryStream(data))
					{
						using (CryptoStream cs = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
						{
							BinaryFormatter binFormatter = new BinaryFormatter();
							return (T)binFormatter.Deserialize(cs);
						}	
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("[UFramework] AES Decryption failed! Error: " + ex.Message);
				Debug.Log("Key: " + key);
				return default(T);
			}
		}	
		// Generate AES key and IV
		public static void GenKey(out byte[] key, out byte[] iv)
		{
			using (Aes aes = Aes.Create())
			{
				aes.GenerateKey();
				aes.GenerateIV();
				key = aes.Key;
				iv = aes.IV;
			}
		}
	}
}