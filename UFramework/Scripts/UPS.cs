using System.Collections;
using UFramework;
using UnityEngine;
using UnityEngine.UI;

namespace UFramework
{
	/***********************************************/
	/*	UPS - The UFrameworkPromotionSystem Library*/
	/***********************************************/

	public class UPS : MonoBehaviour 
	{
		//public Sprite game1thumb, game2thumb, game3thumb;
		
		[Header("Games")]
		/*************** GAMES *******************/
		/**/ public Sprite[] gameThumbs;	   /**/
		/**/ public Image[] games;			   /**/
		/**/ public GameObject[] disabledGames;/**/
		/**/ public string[] gameNames;		   /**/
		/**/public int currentGame, prevGame;  /**/
		/*****************************************/
		
		// This is also used for downloading a game
		public Text loadingMessageText, hotGamesText;
		
		[Header("Screens")]
		/*************** SCREENS ****************/
		/**/ public GameObject loadingScreen; /**/
		/**/ public GameObject promotions;    /**/
		/****************************************/
		
		
		
		public const string UPS_VERSION = "1.3";
		
		[Header("Settings")]
		/********* CONFIG ***********************/
		/**/ public bool useLoadThumbs = true;/**/ 
		/**/ public string creatorName = "";  /**/
		/**/ public int nbOfGames = 2;  /**/
		/****************************************/
		
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
			hotGamesText.text = "MORE GAMES FROM " + creatorName;
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
			/*games[0].sprite = game1thumb;
			games[1].sprite = game2thumb;
			games[2].sprite = game3thumb;*/
			for (int i = 0; i < games.Length; i++)
			{
				//if (gameThumbs[i] == null)
				//{
				//	print("gameThumbs[i] != null == FALSE! Please make sure to set vars in gameThumbs aswell");
				//	return;
				//}
				if (useLoadThumbs)
				{
					games[i].sprite = FindThumbnail(gameNames[i]);
				}
				else
				{					
					games[i].sprite = gameThumbs[i];
				}
			}
		}
		
		// ADDED //
		public Sprite FindThumbnail(string name)
		{
			return Resources.Load<Sprite>("UPSThumbs/" + name);
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
			if (currentGame < nbOfGames)
			{
				currentGame++;
			}
			else
			{
				currentGame = 0;
			}
			if (currentGame > nbOfGames)
			{
				currentGame = 0;
				prevGame = nbOfGames;
			}
			if (currentGame - 1 >= 0) 
			{
				prevGame = currentGame - 1;
			}
			else
			{
				prevGame = nbOfGames;
			}
			games[prevGame].gameObject.SetActive(false);
			if (currentGame > nbOfGames)
			{
				currentGame = 0;
				games[prevGame].gameObject.SetActive(true);
			}
			else
			{
			games[currentGame].gameObject.SetActive(true);}
		}
	}
}