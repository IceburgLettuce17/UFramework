using System.Collections;
using UFramework;
using UnityEngine;
using UnityEngine.UI;

namespace UFramework
{
	// UPS means UFramework Promotion System by the way
	public class UPS : MonoBehaviour 
	{
		public Sprite game1thumb, game2thumb, game3thumb;
		
		public Image[] games;
		
		public Text loadingMessageText;
		
		public GameObject loadingScreen;
		public GameObject promotions;
		
		public int currentGame, prevGame;
		
		public GameObject[] disabledGames;
		
		void Start()
		{
			Initialize("LOADING...");
		}
		
		public void Initialize(string loadingMessage)
		{
			if (Config.debug)
			{
				Debug.Log("Initialize(string loadingMessage= " + loadingMessage + ");");
			}
			loadingMessageText.text = loadingMessage;
			StartCoroutine(LoadingHandler());
		}
		
		public IEnumerator LoadingHandler()
		{
			loadingScreen.SetActive(true);
			yield return new WaitForSeconds(2f);
			
			loadingScreen.SetActive(false);	
			EnterUPS();
				
		}
		
		public void EnterUPS()
		{
			if (Config.debug)
			{
				Debug.Log("EnterUPS();");
			}	
			promotions.SetActive(true);
			LoadGames();
		}
		
		public void LoadGames()
		{
			if (games == null) return;
			games[0].sprite = game1thumb;
			games[1].sprite = game2thumb;
			games[2].sprite = game3thumb;
		}
		
		public void GameClick(string url)
		{
			if (games[currentGame].gameObject != disabledGames[currentGame])
			{
				Application.OpenURL(url);			
			}
			else if (Config.debug)
			{
				Debug.Log("Game is disabled");
			}
		}
		
		public void Destroy(){Object.Destroy(this.gameObject);}
		
		public void ShuffleGame()
		{
			if (currentGame < 2)
			{
				currentGame++;
			}
			else
			{
				currentGame = 0;
			}
			if (currentGame > 2)
			{
				currentGame = 0;
				prevGame = 2;
			}
			if (currentGame - 1 != -1) 
			{
				prevGame = currentGame - 1;
			}
			else
			{
				prevGame = 2;
			}
			games[prevGame].gameObject.SetActive(false);
			games[currentGame].gameObject.SetActive(true);
		}
	}
}