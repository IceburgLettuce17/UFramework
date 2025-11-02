using UFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UFramework
{
	/******************************************/
	/* Game - The Game library version 1.0    */
	/* This will be similiar to J2ME's MIDlet */
	/******************************************/
	
	public class Game : MonoBehaviour 
	{
		public int gameState;
		
		public const string VERSION = "Game.Version.1.0";
		
		void Start()
		{
			if (Config.debug)
			{
				Debug.Log("Width= " + Screen.width + " Height: " + Screen.height);
			}
			
			SetProperty("GameVersion", Application.version);
			
		}
		
		void Update()
		{
			if (gameState == -1)
			{
				if (Config.debug)
				{
					print("gameState is -1; Quitting.");
				}
				Application.Quit();	
			}
		}
		
		public void Request(string request)
		{
			if (request == "Game_UnFullscreen")
			{
				Screen.fullScreen = false;
			}
			
			if (request.StartsWith("Scene:"))
			{
				SceneManager.LoadScene(request.Split("Scene:")[1]);
			}
			
			if (request.StartsWith("https"))
			{
				Application.OpenURL(request);
			}
		}
		
		public void Destroy()
		{
			gameState = -1;
		}
		
		public string GetProperty(string property)
		{
			switch (property)
			{
				case "GameVersion": return Application.version;
				// Example: case "Comment1": return GameConfig.Comment1;
			}
			return string.Empty;
		}
		
		public void SetProperty(string property, string value)
		{
			switch (property)
			{
				case "GameVersion": GameConfig.GameVersion = value; break;
				// Example: case "Comment1": GameConfig.Comment1 = value; break;
			}
		}
	}
}