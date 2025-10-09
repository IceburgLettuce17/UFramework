using System;
using System.IO;
using UnityEngine;
using UFramework;

namespace UFramework.Save
{
	public class SaveFileHandler
	{
		private string fileName = "save.ufsave";
		
		private bool encryptFile = false;
		
		private readonly string encryptionKey = "u{f+r~a>m|e-?w&o%r^k";
		
		public SaveFileHandler(string filePath, string fileName, bool encryptFile)
		{
			this.fileName = fileName;
			this.encryptFile = encryptFile;
		}
		
		// Load data
		public GameData Load()
		{
			string fullPath = Application.persistentDataPath + "/" + fileName; // Only Windows compatibility for now
			GameData loadedData = null;
			if (File.Exists(fullPath))
			{
				try
				{
					// Load serialized data from our JSON file
					string dataToLoad = "";
					using (FileStream stream = new FileStream(fullPath, FileMode.Open))
					{
						using (StreamReader reader = new StreamReader(stream))
						{
							dataToLoad = reader.ReadToEnd();
						}
					}
					
					if (encryptFile)
					{
						dataToLoad = EncryptDecrypt(dataToLoad);
					}
					
					// Now, deserialize it, from JSON, to GameData (C#)
					loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
					
				}
				catch (LoadException le)
				{
					if (Config.debug)
					{
						Debug.LogError("Error while loading from file: " + fileName + "\n" + le);
					}
				}
			}
			return loadedData;
		}
		
		// Save data
		public void Save(GameData data)
		{
			string fullPath = Application.persistentDataPath + "/" + fileName; // Only Windows compatibility for now
			try
			{
					
				// Serialize the GameData object into JSON
				string dataToStore = JsonUtility.ToJson(data, true);
					
				if (encryptFile)
				{
					dataToStore = EncryptDecrypt(dataToStore);
				}
					
				// Finally, write the file to the filesystem
				using (FileStream stream = new FileStream(fullPath, FileMode.Create))
				{
					using (StreamWriter writer = new StreamWriter(stream))
					{
						writer.Write(dataToStore);
					}
				}
			}
			catch (SaveException se)
			{
				if (Config.debug)
				{
					Debug.LogError("Error while saving to file: " + fileName + "\n" + se);
				}
			}
		}
		
		private string EncryptDecrypt(string data)
		{
			string modifiedData = "";
			for (int i = 0; i < data.Length; i++)
			{
				modifiedData += (char) (data[i] ^ encryptionKey[i % encryptionKey.Length]);
			}
			return modifiedData;
		}
	}
	
}
