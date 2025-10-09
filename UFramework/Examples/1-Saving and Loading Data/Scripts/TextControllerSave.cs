using UnityEngine;
using UnityEngine.UI;
using UFramework.Examples;

namespace UFramework.Examples
{
	public class TextControllerSave : MonoBehaviour 
	{
		public Text[] textsToChange;
		
		public GameManagerSave gameManager;
		
		public void Update()
		{
			textsToChange[0].text = gameManager.anInt + " int";
			textsToChange[1].text = gameManager.aBool + " bool";
			textsToChange[2].text = gameManager.aDouble + " double";
		}
	}
}