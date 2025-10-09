using System.Linq;
using System.Collections.Generic;
using System;
using UFramework;
using UFramework.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UFramework.Save
{
	[AddComponentMenu("UFramework/Save/Data Persistence Manager")]
	// The script responsible for initiating the saving/loading of data.
	public class DataPersistenceManager : MonoBehaviour 
	{
		[Header("File storage")]
		[Space(2f)]
		[SerializeField]
		// Save file name w/ extension (saved to persistentDataPath)
		private string fileName;
		
		[SerializeField]
		[Header("NOTE: not changed in editor")]
		private bool encrypt;
		
		// Current game data, a.k.a. the save file
		public /*global::*/GameData data;
		
		// The list of persistent objects (Objects that implement IPersistent)
		public List<IPersistent> persistentObjects;
		
		// The instance of SaveFileHandler
		private SaveFileHandler handler;
		
		// If true, disable saving/loading (For title screens)
		public bool isNotOnCorrectScene;
		
		// If true, disable saving/loading (For sandbox modes)
		public bool cantSave;
		
		// If the current scene name is equal to this variable, disable saving
		public string blacklistedSceneName;
		
		// Static instance of this class
		public static DataPersistenceManager instance { get; private set; }
		
		// Static instance setter
		public void Awake()
		{
			if (instance != null)
			{
				if (Config.debug)
				{
					Debug.LogError("More than one instance of DataPersistenceManager found on the scene.");
				}
			}
			instance = this;
		}
		
		// Save loader
		void Start()
		{
			// This class isn't compatible with WebGL, so refer to WebGLPersistenceManager instead
			if (Application.platform != RuntimePlatform.WebGLPlayer && !cantSave && !isNotOnCorrectScene)
			{
				// Initiate handler, set persistent objects and load data
				handler = new SaveFileHandler(Application.persistentDataPath, fileName, false);
				persistentObjects = FindPersistentObjects();
				LoadData();
			}
			else
			{
				return;
			}
		}
	
		// Reinitialize save file
		public void NewGame()
		{
			data = new GameData();
		}
		
		// Nullify/Reinitialize save data, then save it
		public void NewGame_Nullify()
		{
			data = new GameData();
			SaveData();
		}
		
		// Static version of NewGame()
		public static void ClearDataStatic()
		{
			DataPersistenceManager.instance.data = new GameData();
		}
		
		public bool HasData()
		{
			return data != null;
		}
		
		// Load save data
		public void LoadData() 
		{
			if (Application.platform == RuntimePlatform.WebGLPlayer) return;
			if (SceneManager.GetActiveScene().name == blacklistedSceneName) return;
			// Handle save loading
			data = handler.Load();
			
			if (data == null)
			{
				if (Config.debug)
				{
					Debug.Log("No save data found. Default data will be used.");
				}
				NewGame();
			}
			
			// push data to scripts
			foreach (IPersistent persistentObj in persistentObjects)
			{
				persistentObj.LoadData(data);
			}
			
			if (Config.debug)
			{
				Debug.Log("Loaded persistent data from list");
			}
		}
		
		// Save data
		public void SaveData()
		{
			if (Application.platform == RuntimePlatform.WebGLPlayer) return;
			if (SceneManager.GetActiveScene().name == blacklistedSceneName) return;
			// pass data to scripts
			foreach (IPersistent persistentObj in persistentObjects)
			{
				persistentObj.SaveData(ref data);
			}
			
			if (Config.debug)
			{
				Debug.Log("Saved persistent data from list");
			}
			
			// save to file using data handler
			handler.Save(data);
		}
		
		public void OnApplicationQuit()
		{
			if (!isNotOnCorrectScene && Application.platform != RuntimePlatform.WebGLPlayer && !cantSave)
				SaveData();
		}
		
		// Returns all MonoBehaviours that inherit from IPersistent
		private List<IPersistent> FindPersistentObjects()
		{
			IEnumerable<IPersistent> persistentObjectsLoc = FindObjectsOfType<MonoBehaviour>().OfType<IPersistent>();
			return new List<IPersistent>(persistentObjectsLoc);
		}
	}	
}